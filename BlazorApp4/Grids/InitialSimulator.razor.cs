using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Hosting;
using BlazorApp4.ServiceClients;
using Newtonsoft.Json;
using System.Dynamic;

namespace BlazorApp4.Grids
{
    public partial class InitialSimulator
    {
        [Inject]
        public required SimulatorAccountsServiceClient FxOpDynamicAccountServiceClient { get; set; }
        public List<ExpandoObject> PlanAccounts => GetPlanAccountData();
        public List<ExpandoObject> GetPlanAccountData()
        {
            var planAccounts = FxOpDynamicAccountServiceClient.GetPlanAccountDataAsync().Result.ToList();
            //var data = JsonConvert.DeserializeObject<dynamic>(post.ToString());
            //var planAccounts = FxOpDynamicAccountServiceClient.GetPlanAccountDataAsync().Result.ToList();
            return planAccounts;
        }

        public string[] HideColumnList = { "LabelHoverInfo", "Constant", "RowType", "IsEditableAccount", "ParentConstant", "IsHidden", "IsAccountSpecialStyle" };
        public string[] GroupHideList = { "SubTypeGroup" };

        public bool IsColumnExistIntheHideColumnList(string column)
        {
            return HideColumnList.Contains(column);
        }
        public bool IsColumnExistIntheGroupList(string column)
        {
            return GroupHideList.Contains(column);
        }

    }
}
