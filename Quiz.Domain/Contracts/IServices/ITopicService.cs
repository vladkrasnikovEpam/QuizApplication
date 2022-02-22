using Quiz.Domain.Models;
using Quiz.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Contracts.IServices
{
    public interface ITopicService
    {
        Task<List<TopicModel>> GetAllAsync();
        Task<TopicPaginationModel> GetAllWithPaginationAsync(int pageId);
        Task<int> GetAmountAsync();
        Task<int> Create(TopicParameters param);
        Task DeleteAsync(int id);
    }
}
