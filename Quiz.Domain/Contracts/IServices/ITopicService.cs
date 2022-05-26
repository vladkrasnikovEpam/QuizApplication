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
        Task<TopicModel> Get(int id);
        Task<TopicPaginationModel> GetAllWithPaginationAsync(int pageId);
        Task<int> GetAmountAsync();
        Task<TopicModel> Create(TopicParameters param);
        Task<TopicModel> Update(TopicParameters param);
        Task DeleteAsync(int id);
    }
}
