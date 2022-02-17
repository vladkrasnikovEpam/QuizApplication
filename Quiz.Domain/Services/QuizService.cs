using AutoMapper;
using Quiz.Core.IUoWs;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Models;
using Quiz.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQAUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public QuizService(IQAUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<TopicModel>> GetAllAsync()
        {
            var list = await this.unitOfWork.QuizRepository.GetAlltopics();
            return mapper.Map<List<TopicModel>>(list);
        }
        public async Task<int> CreateRecord()
        {
            this.unitOfWork.QuizRepository.CreateRecord();
            return 1;
        }
    }
}
