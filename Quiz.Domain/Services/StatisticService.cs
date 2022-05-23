using AutoMapper;
using Quiz.Core.IUoWs;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Models;
using Quiz.Infrastructure.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IQAUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public StatisticService(IQAUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<StatisticModel> Get()
        {
            var stats = await unitOfWork.StatisticRepository.Get();
            return mapper.Map<StatisticModel>(stats);
        }
    }
}
