using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiskApplication.Web.Controllers
{
    public class RiskController : Controller
    {
        // GET: Risk
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerSettledBets()
        {            
            return View();
        }
    }
}