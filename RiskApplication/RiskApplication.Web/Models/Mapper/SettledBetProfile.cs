using AutoMapper;
using RiskApplication.Domain.Models;

namespace RiskApplication.Web.Models.Mapper
{
    public class SettledBetProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<SettledBet, SettledBetVewModel>();
        }
    }
}