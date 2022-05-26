using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Contracts.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService service;
        public StatisticController(IStatisticService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var stats = await service.Get();
            return Ok(stats);
        }
    }
}
