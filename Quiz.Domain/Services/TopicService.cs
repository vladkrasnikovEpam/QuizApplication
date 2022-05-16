using AutoMapper;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Core.IUoWs;
using Quiz.Domain.Constants;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Models;
using Quiz.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Services
{
    public class TopicService : ITopicService
    {
        private readonly IQAUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public TopicService(IQAUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<int> Create(TopicParameters param)
        {
            var topic = mapper.Map<Topic>(param);
            try
            {
                unitOfWork.TopicRepository.Create(topic);
                await unitOfWork.SaveAsync();
                foreach (var question in param.Question)
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
                await unitOfWork.SaveAsync();
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
                return 0;
            }
            return 1;
        }

        public async Task<int> GetAmountAsync()
        {
            return await unitOfWork.TopicRepository.GetAmount();
        }

        public async Task DeleteAsync(int id)
        {
            var topic = await unitOfWork.TopicRepository.GetTopicById(id);
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
    }
}
