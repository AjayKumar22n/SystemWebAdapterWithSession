using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.SystemWebAdapters;
namespace QWE.ASDF.WebAdapterHelper
{
    public static class Helper
    {
        public static string UserAgent => HttpContext.Current.Request.UserAgent;

        public static string GetUserAgent(HttpContextBase context) => context.Request.UserAgent;

    }

    public static class SessionInfo
    {
        public static string GetUserName => HttpContext.Current.Session["givenusername"] != null ? HttpContext.Current.Session["givenusername"].ToString() : "";


        //Microsoft.AspNetCore.SystemWebAdapters.SessionState
    }
}
