using Quiz.Core.Entities.Quiz_App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Core.IRepositories
{
    public interface IAnswerRepository
    {
        void Create(Answer entity);
    }
}
