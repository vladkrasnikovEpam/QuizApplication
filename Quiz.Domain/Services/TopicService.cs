using AutoMapper;
using Microsoft.Extensions.Logging;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IUoWs;
using Quiz.Domain.Constants;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Exceptions;
using Quiz.Domain.Models;
using Quiz.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Services
{
    public class TopicService : BaseService, ITopicService
    {
        private readonly IQAUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private string _entityName = nameof(Topic);
        public TopicService(ILogger<BaseService> logger,
            IQAUnitOfWork unitOfWork, 
            IMapper mapper) : base(logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        //public TopicService() { }

        public async Task<List<TopicModel>> GetAllAsync()
        {
            var list = await unitOfWork.TopicRepository.GetAlltopics();
            return mapper.Map<List<TopicModel>>(list);
        }
        public async Task<TopicModel> Create(TopicParameters param)
        {
            var topic = mapper.Map<Topic>(param);
            try
            {
                unitOfWork.TopicRepository.Create(topic);
                await unitOfWork.SaveAsync();
                if (topic.Question.Count > 0)
                {
                    foreach (var question in topic.Question)
                    {
                        question.TopicId = topic.Id;
                        var questionEntity = mapper.Map<Question>(question);
                        unitOfWork.QuestionRepository.Create(questionEntity);
                        await unitOfWork.SaveAsync();
                        foreach (var answer in question.Answer)
                        {
                            answer.QuestionId = questionEntity.Id;
                            var mappedAnswer = mapper.Map<Answer>(answer);
                            unitOfWork.AnswerRepository.Create(mappedAnswer);
                        }
                    }
                }
                await unitOfWork.SaveAsync();
                return mapper.Map<TopicModel>(topic);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
                return mapper.Map<TopicModel>(topic);
            }
        }

        public async Task<int> GetAmountAsync()
        {
            return await unitOfWork.TopicRepository.GetAmount();
        }

        public async Task DeleteAsync(int id)
        {
            var topic = await unitOfWork.TopicRepository.Get(id);
            if (topic == null) throw new KeyNotFoundException();
            unitOfWork.TopicRepository.Delete(topic);
            await unitOfWork.SaveAsync();
        }

        public async Task<TopicPaginationModel> GetAllWithPaginationAsync(int pageId)
        {
            TopicPaginationModel model = new TopicPaginationModel();
            PaginationModel paginationModel = new PaginationModel();
            if (pageId < 0) throw new KeyNotFoundException();
            paginationModel.Next = QuizConstants.TopicPageUrl + (pageId + 1);
            paginationModel.Previous = QuizConstants.TopicPageUrl + (pageId - 1);
            var startIndex = (pageId - 1) * QuizConstants.NumberOfTopicsPerPage;
            var topicsList = await unitOfWork.TopicRepository.GetRangeOfTopics(startIndex, QuizConstants.NumberOfTopicsPerPage);
            model.Topic = mapper.Map<List<TopicModel>>(topicsList);
            model.Pagination = paginationModel;
            return model;
        }

        public async Task<TopicModel> Update(TopicParameters param)
        {
            var topic = await unitOfWork.TopicRepository.Get(param.Id);
            if (topic == null)
                ThrowNotFoundException(param.Id, _entityName);

            mapper.Map(param, topic);

            topic.Id = param.Id;
            unitOfWork.TopicRepository.Update(topic);
            await unitOfWork.SaveAsync();
            return mapper.Map<TopicModel>(topic);
        }

        public async Task<TopicModel> Get(int id)
        {
            var model = await unitOfWork.TopicRepository.Get(id);
            if (model == null)
            {
                var message = string.Format(QuizConstants.EntityNotFound, _entityName, id);
                throw new NotFoundException(message);
            }
            return mapper.Map<TopicModel>(model);
        }
    }
}
