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
                   .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                   .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                   .ForMember(dst => dst.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                   .ForMember(dst => dst.MembershipTypeId, opt => opt.MapFrom(src => src.MembershipTypeId))
                   .ForMember(dst => dst.IsSybscribedToNewsletter, opt => opt.MapFrom(src => src.IsSybscribedToNewsletter));

                cfg.CreateMap<CustomerDto, Customer>()
                   .ForMember(dst => dst.Id, opt => opt.Ignore())
                   .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                   .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                   .ForMember(dst => dst.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                   .ForMember(dst => dst.MembershipTypeId, opt => opt.MapFrom(src => src.MembershipTypeId))
                   .ForMember(dst => dst.MembershipType, opt => opt.Ignore())
                   .ForMember(dst => dst.IsSybscribedToNewsletter, opt => opt.MapFrom(src => src.IsSybscribedToNewsletter));

                cfg.CreateMap<MembershipType, MembershipTypeDto>()
                   .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));


                cfg.CreateMap<Movie, MovieDto>()
                   .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                   .ForMember(dst => dst.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                   .ForMember(dst => dst.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock))
                   .ForMember(dst => dst.GenreId, opt => opt.MapFrom(src => src.GenreId))
                   .ForMember(dst => dst.AddedDate, opt => opt.MapFrom(src => src.AddedDate));

                cfg.CreateMap<MovieDto, Movie>()
                   .ForMember(dst => dst.Id, opt => opt.Ignore())
                   .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                   .ForMember(dst => dst.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                   .ForMember(dst => dst.NumberInStock, opt => opt.MapFrom(src => src.NumberInStock))
                   .ForMember(dst => dst.GenreId, opt => opt.MapFrom(src => src.GenreId))
                   .ForMember(dst => dst.AddedDate, opt => opt.MapFrom(src => src.AddedDate))
                   .ForMember(dst => dst.Genre, opt => opt.Ignore());

                cfg.CreateMap<Genre, GenreDto>()
                   .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));

                //cfg.CreateMap<Rental, RentalDto>()
                //   .ForMember(dst => dst.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                //   .ForMember(dst => dst.MovieId, opt => opt.MapFrom(src => src.MovieId));

                //cfg.CreateMap<RentalDto, Rental>()
                //   .ForMember(dst => dst.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                //   .ForMember(dst => dst.MovieId, opt => opt.MapFrom(src => src.MovieId));
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