using Quiz.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Core.IUoWs
{
    public interface IQAUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IQuizRepository QuizRepository { get; }
    }
}
