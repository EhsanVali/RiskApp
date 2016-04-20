using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using RiskApplication.Domain;
using RiskApplication.Web.Models;

namespace RiskApplication.Web.Controllers
{
    public class RiskController : Controller
    {
        private readonly IRiskAnalysisService _riskAnalysisService;

        public RiskController(IRiskAnalysisService riskAnalysisService)
        {
            _riskAnalysisService = riskAnalysisService;
        }

        public ActionResult Index()
        {
            var betsAndRisks = _riskAnalysisService.GetUnsettledBetsRiskAnalysis();
            var list = Mapper.Map<IEnumerable<UnsettledBetAndRiskViewModel>>(betsAndRisks);
            return View(list);
        }

        public ActionResult CustomerSettledBets()
        {
            var customer = _riskAnalysisService.GetCustomers();
            var list = Mapper.Map<IEnumerable<CustomerVewModel>>(customer);
            return View(list);
        }

        [Route("/Risk/GetSettledBet/{id}")]
        public ActionResult GetSettledBet(int id)
        {
            var settledBets = _riskAnalysisService.ReadAllSettledBets(id);
            var list = Mapper.Map<IEnumerable<SettledBetVewModel>>(settledBets);
            return PartialView("SettledBets", list);
        }
    }
}