using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Parameters;
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
        private readonly ITopicService service;
        public HomeController(ITopicService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public async Task<ActionResult> GetRoleAdmin()
        {
            return Ok("Ваша роль: администратор");
        }
    }
}
