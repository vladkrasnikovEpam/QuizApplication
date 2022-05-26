using Microsoft.EntityFrameworkCore;
using Quiz.Core.Data;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizContext context;
        public QuestionRepository(QuizContext context)
        {
            this.context = context;
        }
        public void Create(Question entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public async Task<int> GetQuestionId(Question entity)
        {
            return await context.Question.Where(x => x.QuestionName.Equals(entity.QuestionName) && x.TopicId == entity.TopicId).Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
