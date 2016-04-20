using AutoMapper;
using RiskApplication.Domain.Models;

namespace RiskApplication.Web.Models.Mapper
{
    public class RiskProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UnsettledBetRiskAnalysis, UnsettledBetAndRiskViewModel>()
                .ForMember(p => p.CustomerId, opt => opt.MapFrom(t => t.UnsettledBet.CustomerId))
                .ForMember(p => p.Event, opt => opt.MapFrom(t => t.UnsettledBet.Event))
                .ForMember(p => p.Participant, opt => opt.MapFrom(t => t.UnsettledBet.Participant))
                .ForMember(p => p.Stake, opt => opt.MapFrom(t => t.UnsettledBet.Stake))
                .ForMember(p => p.ToWin, opt => opt.MapFrom(t => t.UnsettledBet.ToWin))
                .ForMember(p => p.IsHighPrice, opt => opt.MapFrom(t => t.RiskAnalysis.IsHighPrice))
                .ForMember(p => p.IsHighStake, opt => opt.MapFrom(t => t.RiskAnalysis.IsHighStake))
                .ForMember(p => p.IsUnusuallyHighStake, opt => opt.MapFrom(t => t.RiskAnalysis.IsUnusuallyHighStake))
                .ForMember(p => p.HasUnusualWinRate, opt => opt.MapFrom(t => t.RiskAnalysis.HasUnusualWinRate));
        }
    }
}