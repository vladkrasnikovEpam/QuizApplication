using AutoMapper;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Login));
        }
    }
}
