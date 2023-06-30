using Application.Common;
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
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();
        }
    }
}
