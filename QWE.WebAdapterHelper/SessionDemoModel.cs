

using System.ComponentModel.DataAnnotations;

namespace QWE.ASDF.WebAdapterHelper
{
    public class SessionDemoModel
    {
        [Display(Name = "Integer session item Application Id")]
        public int? applicationId { get; set; }

        [Display(Name = "String session item Application Name")]
        public string applicationName { get; set; }
    }
}
