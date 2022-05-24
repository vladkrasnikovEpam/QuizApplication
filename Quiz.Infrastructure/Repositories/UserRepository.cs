using Microsoft.EntityFrameworkCore;
using Quiz.Core.Data;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QuizContext context;
        public UserRepository(QuizContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await context.User.ToListAsync();
        }
        public async Task<User> GetUser(string email, string password)
        {
            return await context.User
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Login.Equals(email) && x.Password == password);
        }
    }
}
