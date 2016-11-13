using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public static IMapper Mapper;

        public static void RegisterMappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>()
                    .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dst => dst.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                    .ForMember(dst => dst.MembershipTypeId, opt => opt.MapFrom(src => src.MembershipTypeId))
                    .ForMember(dst => dst.IsSybscribedToNewsletter, opt => opt.MapFrom(src => src.IsSybscribedToNewsletter));

                cfg.CreateMap<CustomerDto, Customer>()
                    .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dst => dst.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                    .ForMember(dst => dst.MembershipTypeId, opt => opt.MapFrom(src => src.MembershipTypeId))
                    .ForMember(dst => dst.MembershipType, opt => opt.Ignore())
                    .ForMember(dst => dst.IsSybscribedToNewsletter, opt => opt.MapFrom(src => src.IsSybscribedToNewsletter));
            });


            try
            {
                config.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                ex.ToString();
                System.Diagnostics.Debugger.Break();
                throw;
            }

            Mapper = config.CreateMapper();
        }
    }
}