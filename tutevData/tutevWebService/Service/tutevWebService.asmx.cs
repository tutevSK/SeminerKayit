using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;

namespace tutevWebService.Service
{
    /// <summary>
    /// Summary description for tutevWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class tutevWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        
        StringBuilder sb;
        [WebMethod]
        public string Deneme(int kulupId) 
        {
            sb = new StringBuilder();
            if (kulupId==1)
            {
                sb.Append("Bilgisayar");
                return sb.ToString();
            }
            else
            {
                return null;
            }

        }


    }
}
