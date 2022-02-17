using Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Contracts.IServices
{
    public interface IQuizService
    {
        Task<List<TopicModel>> GetAllAsync();
        Task<int> CreateRecord();
    }
}
