using Quiz.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Services
{
    public class QuizService
    {
        private readonly QuizRepository quizRepository;
        public QuizService(QuizRepository repository)
        {
            this.quizRepository = repository;
        }

        public async Task<int> GetAll()
        {
            var s = await this.quizRepository.GetAlltopics();
            return 1;
        }
        public async Task<int> CreateRecord()
        {
            this.quizRepository.CreateRecord();
            return 1;
        }
    }
}
