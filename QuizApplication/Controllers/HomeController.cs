using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly QuizService service;
        public HomeController(QuizService service)
        {
            this.service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            await service.GetAll();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTopic()
        {
            await service.CreateRecord();
            return Ok();
        }
    }
}
