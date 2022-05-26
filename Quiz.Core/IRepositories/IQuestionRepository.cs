using Quiz.Core.Entities.Quiz_App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.IRepositories
{
    public interface IQuestionRepository
    {
        void Create(Question entity);
        Task<int> GetQuestionId(Question entity);
    }
}
