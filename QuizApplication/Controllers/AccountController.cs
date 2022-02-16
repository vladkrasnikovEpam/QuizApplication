using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public AccountController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        // тестовые данные вместо использования базы данных
        private List<User> people = new List<User>
        {
            new User { Email="vladyslav_krasnikov@epam.com", Password="fakepass"},
            new User { Email="qwerty@gmail.com", Password="55555"}
        };

        [HttpPost("token")]
        public IActionResult Token(string username, string password)
        {
            ClaimsIdentity identity;
            var person = GetIdentity(username, password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Result.Username)
                    //new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                identity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                //    return claimsIdentity;
            }
            else
            {
                return null;
            }

            //if user not found

            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // create JWT-token
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
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
            //User person = people.FirstOrDefault(x => x.Email == username && x.Password == password);
            var users = await userService.GetAllAsync();
            UserModel person = users.FirstOrDefault(x => x.Username == username && x.Password == password);
            return person;
        }
    }
}

