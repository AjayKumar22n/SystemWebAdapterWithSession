
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorApp4.ServiceClients
{
    public class SimulatorAccountsServiceClient
    {
        /*
        private readonly HttpClient _httpClient;
        public FxOpDynamicAccountServiceClient(HttpClient httpClient) { _httpClient = httpClient; }

        public async Task<IEnumerable<ExpandoObject>> GetPlanAccountDataAsync()
        {
            try
            {
                var accounts = await _httpClient.GetStringAsync("Json/plan.json").ConfigureAwait(false);

                var accountList = JsonConvert.DeserializeObject<ExpandoObject[]>(accounts);

                //var accountList = await _httpClient.GetFromJsonAsync<ExpandoObject[]>("Json/plan.json").ConfigureAwait(false);
                return accountList;
            }
            catch(Exception ex)
            {
                string aa = ex.Message;
            }
            return null;*/
        /*
        var response = await _httpClient.GetAsync("api/Plan/GetAccountsByPlan");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MyData>();
        */
        //}

        //The below is for reading content from the same blazor app.

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public SimulatorAccountsServiceClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<IEnumerable<ExpandoObject>> GetPlanAccountDataAsync()
        {
            try
            {
                var planRootPath = _configuration.GetValue<string>("QWEServices:PlanJsonRootPath");
                var httpClient = _httpClientFactory.CreateClient();
                var accounts = await httpClient.GetStringAsync(planRootPath + "/Json/plan.json").ConfigureAwait(false);

                var accountList = JsonConvert.DeserializeObject<ExpandoObject[]>(accounts);

                //var accountList = await _httpClient.GetFromJsonAsync<ExpandoObject[]>("Json/plan.json").ConfigureAwait(false);
                return accountList;
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            return null;
        }
    }
}
