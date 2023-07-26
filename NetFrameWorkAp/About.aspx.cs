using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetFrameWorkAp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["frameworksession"] = "abc";
            var x = Session["coresession"] != null ? Session["coresession"].ToString() : "core not set";
        }
    }
}