using Quiz.Core.Entities.Quiz_App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.IRepositories
{
    public interface ITopicRepository
    {
        void Create(Topic entity);
        void Delete(Topic entity);
        Task<IEnumerable<Topic>> GetAlltopics();
        Task<IEnumerable<Topic>> GetRangeOfTopics(int skipRows, int amount);
        Task<int> GetTopicId(Topic entity);
        Task<int> GetAmount();
        Task<Topic> GetTopicById(int id);
    }
}
