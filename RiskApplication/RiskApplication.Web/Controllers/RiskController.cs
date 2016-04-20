using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiskApplication.Domain;

namespace RiskApplication.Web.Controllers
{
    public class RiskController : Controller
    {
        private readonly IRiskAnalysisService _riskAnalysisService;

        public RiskController(IRiskAnalysisService riskAnalysisService)
        {
            _riskAnalysisService = riskAnalysisService;
        }

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