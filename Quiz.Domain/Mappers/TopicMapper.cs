using AutoMapper;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Domain.Models;
using Quiz.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Mappers
{
    public class TopicMapper : Profile
    {
        public TopicMapper()
        {
            CreateMap<Topic, TopicModel>();
            CreateMap<TopicParameters, Topic>()
                .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Description, src => src.MapFrom(opt => opt.Description));
        }
    }
}
