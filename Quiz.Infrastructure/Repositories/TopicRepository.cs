using Microsoft.EntityFrameworkCore;
using Quiz.Core.Data;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly QuizContext context;
        public TopicRepository(QuizContext context)
        {
            this.context = context;
        }
        public void Create(Topic entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(Topic entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Topic>> GetAlltopics()
        {
            return await context.Topic.ToListAsync();
        }

        public async Task<int> GetAmount()
        {
            return await context.Topic.CountAsync();
        }

        public async Task<IEnumerable<Topic>> GetRangeOfTopics(int skipRows, int amount)
        {
            return await context.Topic.Skip(skipRows).Take(amount).ToListAsync();
        }

        public async Task<Topic> GetTopicById(int id)
        {
            return await context.Topic.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetTopicId(Topic entity)
        {
            return await context.Topic.Where(x => x.Name.Equals(entity.Name) && x.Description == entity.Description).Select( x => x.Id).FirstOrDefaultAsync();
        }
    }
}
