using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Models;
using Quiz.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService service;
        public TopicController(ITopicService service)
        {
            this.service = service;
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<List<TopicModel>>> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<TopicModel>>> GetById(int id)
        {
            var topic = await service.Get(id);
            return Ok(topic);
        }

        [Authorize]
        [HttpGet("page/{pageId}")]
        public async Task<ActionResult<TopicPaginationModel>> GetAllWithPagination(int pageId)
        {
            return Ok(await service.GetAllWithPaginationAsync(pageId));
        }

        [Authorize]
        [HttpGet("amount")]
        public async Task<ActionResult<int>> GetAmount()
        {
            return Ok(await service.GetAmountAsync());
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] TopicParameters model)
        {
            return Ok(await service.Create(model));
        }
        
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] TopicParameters model)
        {
            return Ok(await service.Update(model));
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
