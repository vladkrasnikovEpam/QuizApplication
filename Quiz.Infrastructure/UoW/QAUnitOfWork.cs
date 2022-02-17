using Quiz.Core.Data;
using Quiz.Core.IRepositories;
using Quiz.Core.IUoWs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.UoW
{
    public class QAUnitOfWork : IQAUnitOfWork
    {
        private readonly QuizContext context;
        public IUserRepository UserRepository { get; private set; }
        public IQuizRepository QuizRepository { get; private set; }
        public QAUnitOfWork(QuizContext context,
            IUserRepository userRepository,
            IQuizRepository quizRepository)
        {
            this.context = context;
            UserRepository = userRepository;
            QuizRepository = quizRepository;
        }
        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
