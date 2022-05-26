using Microsoft.EntityFrameworkCore;
using Quiz.Core.Data;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly QuizContext _context;
        public  StatisticRepository (QuizContext context)
        {
            _context = context;
        }
        public async Task<Statistic> Get()
        {
            return await _context.Statistic.FirstOrDefaultAsync();
        }
    }
}
