using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using QWE.ASDF.WebAdapterHelper;

namespace NetFrameWorkAp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SystemWebAdapterConfiguration.AddSystemWebAdapters(this)
             .AddProxySupport(options => options.UseForwardedHeaders = true)
             .AddJsonSessionSerializer(options =>
             {
                 // Serialization/deserialization requires each session key to be registered to a type
                 RemoteServiceUtils.RegisterSessionKeys(options.KnownKeys);
             })
             // Provide a strong API key that will be used to authenticate the request on the remote app for querying the session
             // ApiKey is a string representing a GUID
             .AddRemoteAppServer(options => options.ApiKey = ConfigurationManager.AppSettings["RemoteAppApiKey"])
             .AddSessionServer();
        }
    }
}