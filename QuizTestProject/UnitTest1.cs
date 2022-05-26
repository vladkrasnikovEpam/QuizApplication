using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using Quiz.Core.Data;
using Quiz.Core.IRepositories;
using Quiz.Core.IUoWs;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Services;
using QuizApplication.Controllers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuizTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private readonly QuizContext _context;
        private CancellationToken cancellationToken;

        [TestMethod]
        public async Task TestMethod1()
        {
            //Mock<QuizContext> mock = new Mock<QuizContext>();
            //mock.Setup(r => r.Topic.ToList()).ReturnsAsync(3);
            //var service = Substitute.For<ITopicService>();
            //var expectedResult = await _context.Topic.CountAsync();
            //var actualResult = await service.GetAmountAsync();


            //Assert.AreEqual(expectedResult, actualResult);
            //TopicService topicService = new TopicService(unitOfWork, mapper);
            //Mock<ITopicService> mockservice = new Mock<ITopicService>();
            //mockservice.Setup(t => t.GetAllAsync()).ReturnsAsync();

            //TopicService fileWordCounter = new TopicService(mockservice. .Object);

            //var res = await service.GetAllAsync();
            //Assert.IsNotNull(res);
        }
        [TestMethod]
        public async Task TestMethod2()
        {
            Mock<ITopicRepository> mock = new Mock<ITopicRepository>();
            int expectedResult = 3;

            mock.Setup(r => r.GetAmount()).ReturnsAsync(3);

            ITopicRepository topicRep = mock.Object;
            var actualResult = await topicRep.GetAmount();

            Assert.AreEqual(expectedResult, actualResult);
            //TopicService topicService = new TopicService(unitOfWork, mapper);
            //var res = await topicService.GetAllWithPaginationAsync(3);
            ////var ans = topicService.GetAmountAsync();
            //Assert.IsNotNull(res);
        }
        [TestMethod]
        public async Task TestMethod3()
        {
            var logger = Mock.Of<ITopicService>();
            var controller = new TopicController(logger);
            var expectedResult = 5;

            var actualResult = await controller.GetAmount();

            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
