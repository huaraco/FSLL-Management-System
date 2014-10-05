using FSLL.MS.Feedback.Common;
using FSLL.MS.Feedback.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSLL.MS.Feedback.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //dynamic c = Newtonsoft.Json.JsonConvert.DeserializeObject("[{ID:1, name:\"wang\"},{ID:2, name:\"Li\"}]");
            //dynamic d = new[] { new { user = "some user" }, new { user = "some user2" }, };
            //if (d is Array)
            //    ViewBag.Test = d;
            //else
            //{
            //    ViewBag.Test = c;
            //}
            //System.Web.Configuration.WebConfigurationManager.AppSettings["FSLLCoreServiceURL"];
            WebServiceManager _wsManager = new WebServiceManager("http://localhost/fsllCore");
            var members = _wsManager.Get("/Member/GetMember?name=王尊华");

            ViewBag.Test = members;

            //RequirementService _service = new RequirementService();
            //ViewBag.Test = _service.ListMemberRequirements("王尊华");


            return View();
        }
    }
}
