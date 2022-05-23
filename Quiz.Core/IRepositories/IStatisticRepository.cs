using Quiz.Core.Entities.Quiz_App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.IRepositories
{
    public interface IStatisticRepository
    {
        Task<Statistic> Get();
    }
}
