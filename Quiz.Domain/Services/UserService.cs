using AutoMapper;
using Microsoft.Extensions.Logging;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IUoWs;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Models;
using Quiz.Domain.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IQAUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(ILogger<BaseService> logger,
            IQAUnitOfWork unitOfWork, IMapper mapper) : base(logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserModel> Create(LoginModel login)
        {
            var user = await unitOfWork.UserRepository.GetUser(login.Email, login.Password);
            if (user != null)
                throw new ArgumentException();
            var mappedUser = mapper.Map<User>(login);
            mappedUser.RoleId = 2;

            user = await unitOfWork.UserRepository.Create(mappedUser);
            await unitOfWork.SaveAsync();

            return mapper.Map<UserModel>(user);
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var list = await unitOfWork.UserRepository.GetAllUsersAsync();
            return mapper.Map<List<UserModel>>(list);
        }
        public async Task<UserModel> GetUser(LoginModel login)
        {
            var user = await unitOfWork.UserRepository.GetUser(login.Email, login.Password);
            return mapper.Map<UserModel>(user);
        }

    }
}
