using Quiz.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Core.IUoWs
{
    public interface IQAUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        ITopicRepository TopicRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }
    }
}
