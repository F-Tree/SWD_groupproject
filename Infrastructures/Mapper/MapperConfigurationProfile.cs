using Application.Common;
using Application.ViewModel.PersonViewModel;
using Application.ViewModel.UserViewModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Mapper
{
    public  class MapperConfigurationProfile:Profile
    {
       public MapperConfigurationProfile() 
       {
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));

            CreateMap<UpdateDTO, User>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<UpdatePersonDTO, Person>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(x => x.DateOfDeath, opt => opt.MapFrom(src => src.DateOfDeath))
                .ForMember(x => x.RestingPlace, opt => opt.MapFrom(src => src.RestingPlace))
                .ReverseMap();
        }
    }
}
