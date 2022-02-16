using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Quiz.Core.Entities.Quiz_App;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Models;
using Quiz.Domain.Models.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuizApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public AccountController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost("token")]
        public IActionResult Token(string username, string password)
        {
            ClaimsIdentity identity;
            var person = GetIdentity(username, password);
            if (person.Result != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Result.Username)
                    //new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                identity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            }
            else
            {
                throw new SecurityTokenException();
            }

            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>();
            var now = DateTime.UtcNow;
            // create JWT-token
            var jwt = new JwtSecurityToken(
                    issuer: authOptions.ISSUER,
                    audience: authOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(authOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(authOptions.KEY), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private async Task<UserModel> GetIdentity(string username, string password)
        {
            var users = await userService.GetAllAsync();
            UserModel person = users.FirstOrDefault(x => x.Username == username && x.Password == password);
            return person;
        }
    }
}

