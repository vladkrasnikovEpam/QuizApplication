using AutoMapper;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Domain.Models;
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
        }
    }
}
