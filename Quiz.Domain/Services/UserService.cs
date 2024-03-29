﻿using AutoMapper;
using Quiz.Core.IUoWs;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IQAUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IQAUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var list = await unitOfWork.UserRepository.GetAllUsersAsync();
            return mapper.Map<List<UserModel>>(list);
        }
        public async Task<UserModel> GetUser(string username, string password)
        {
            var user = await unitOfWork.UserRepository.GetUser(username, password);
            return mapper.Map<UserModel>(user);
        }

    }
}
