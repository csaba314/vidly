using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore()); // to fix the Id bug

            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            // add a new mapping for MembershipType <=> MembershipTypeDto
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            // add a new mapping for Genre => GenreDto
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}