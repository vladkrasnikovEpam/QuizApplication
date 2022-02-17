using Quiz.Core.Entities.Quiz_App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
