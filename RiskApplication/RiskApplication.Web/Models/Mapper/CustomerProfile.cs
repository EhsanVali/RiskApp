using AutoMapper;
using RiskApplication.Domain.Models;

namespace RiskApplication.Web.Models.Mapper
{
    public class CustomerProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Customer, CustomerVewModel>();
        }
    }
}