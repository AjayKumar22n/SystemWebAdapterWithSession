using BlazorApp4.Data;
using QWE.ASDF.WebAdapterHelper;
using BlazorCore;
using BlazorApp4.ServiceClients;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSystemWebAdapters();
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddTelerikBlazor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();//.AddHubOptions(a => { a.})
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<SimulatorAccountsServiceClient>();

builder.Services.AddLocalStorageServices();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddHttpClient();
builder.Services.AddSystemWebAdapters()
    .AddJsonSessionSerializer(options =>
    {
        // Serialization/deserialization requires each session key to be registered to a type
        RemoteServiceUtils.RegisterSessionKeys(options.KnownKeys);
    })
//.WrapAspNetCoreSession()
.AddRemoteAppClient(options =>
{
    //options.RemoteAppUrl = new(builder.Configuration["ReverseProxy:Clusters:frameworkCluster:Destinations:frameworkDestinationApp:Address"]);
    options.RemoteAppUrl = new(builder.Configuration["ReverseProxy:Clusters:fallbackCluster:Destinations:fallbackApp:Address"]);
    //this key should be same 
    options.ApiKey = builder.Configuration["RemoteAppApiKey"];
})
.AddSessionClient();

//builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});


var app = builder.Build();
app.UseForwardedHeaders();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//app.UseCors(x => x.AllowAnyOrigin());
app.UseAuthorization();

app.UseSystemWebAdapters();
//app.MapBlazorHub();
app.MapBlazorHub().RequireSystemWebAdapterSession();
app.MapRazorPages();//.RequireSystemWebAdapterSession();
app.MapBlazorPages("/_Host");
app.MapReverseProxy();

app.Run();