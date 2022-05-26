using Quiz.Domain.Models;
using Quiz.Domain.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Contracts.IServices
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel> GetUser(LoginModel login);
        Task<UserModel> Create(LoginModel login);
    }
}
