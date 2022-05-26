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
        public ITopicRepository TopicRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get; private set; }
        public IAnswerRepository AnswerRepository { get; private set; }
        public IStatisticRepository StatisticRepository { get; private set; }
        public QAUnitOfWork(QuizContext context,
            IUserRepository userRepository,
            ITopicRepository topicRepository,
            IQuestionRepository questionRepository,
            IAnswerRepository answerRepository,
            IStatisticRepository statisticRepository)
        {
            this.context = context;
            UserRepository = userRepository;
            TopicRepository = topicRepository;
            QuestionRepository = questionRepository;
            AnswerRepository = answerRepository;
            StatisticRepository = statisticRepository;
        }
        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
