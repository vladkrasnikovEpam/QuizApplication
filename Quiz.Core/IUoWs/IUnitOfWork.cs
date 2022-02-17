using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.IUoWs
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
