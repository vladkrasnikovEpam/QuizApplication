using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IQuizService service;
        public HomeController(IQuizService service)
        {
            this.service = service;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateTopic()
        {
            await service.CreateRecord();
            return Ok();
        }
    }
}
