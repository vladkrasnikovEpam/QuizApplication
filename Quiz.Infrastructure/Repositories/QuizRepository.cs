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
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizContext context;
        public QuizRepository(QuizContext context)
        {
            this.context = context;
        }
        public void CreateRecord()
        {
            Topic entity = new Topic();
            entity.Name = "Sport";
            entity.Description = "Discover what sport best fits u";
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }
        public async Task<IEnumerable<Topic>> GetAlltopics()
        {
            return await context.Topic.ToListAsync();
        }
    }
}
