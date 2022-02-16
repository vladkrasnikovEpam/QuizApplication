using Quiz.Core.Entities.Quiz_App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.IRepositories
{
    public interface IQuizRepository
    {
        void CreateRecord();
        Task<IEnumerable<Topic>> GetAlltopics();
        //Task<IEnumerable<Topic>> d();
    }
}
