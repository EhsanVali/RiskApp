using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using RiskApplication.Domain;
using RiskApplication.Web.Models;

namespace RiskApplication.Web.Controllers
{
    public class RiskController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRiskAnalysisService _riskAnalysisService;

        public RiskController(IRiskAnalysisService riskAnalysisService, IMapper mapper)
        {
            _mapper = mapper;
            _riskAnalysisService = riskAnalysisService;
        }

        public ActionResult Index()
        {
            var betsAndRisks = _riskAnalysisService.GetUnsettledBetsRiskAnalysis();
            var list = _mapper.Map<IEnumerable<UnsettledBetAndRiskViewModel>>(betsAndRisks.ToList());
            return View(list);
        }

        public ActionResult CustomerSettledBets()
        {
            var customers = _riskAnalysisService.GetCustomers();
            var list = _mapper.Map<IEnumerable<CustomerVewModel>>(customers);
            return View(list);
        }

        [Route("/Risk/GetSettledBet/{id}")]
        public ActionResult GetSettledBet(int id)
        {
            var settledBets = _riskAnalysisService.ReadAllSettledBets(id);
            var list = _mapper.Map<IEnumerable<SettledBetVewModel>>(settledBets);
            return PartialView("SettledBets", list);
        }
    }
}