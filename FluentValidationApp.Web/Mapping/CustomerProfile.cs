using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard, CustomerDto>();

            CreateMap<Customer, CustomerDto>().IncludeMembers(x=>x.CreditCard)
                .ForMember(dest => dest.Ad, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Yas, opt => opt.MapFrom(x => x.Age))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FullName2()));
                
            //CreateMap<CustomerDto, Customer>();-reversemap() diger yolu
        }
    }
}
