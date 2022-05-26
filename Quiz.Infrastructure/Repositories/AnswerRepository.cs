using Microsoft.EntityFrameworkCore;
using Quiz.Core.Data;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizContext context;
        public AnswerRepository(QuizContext context)
        {
            this.context = context;
        }

        public void Create(Answer entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }
    }
}
