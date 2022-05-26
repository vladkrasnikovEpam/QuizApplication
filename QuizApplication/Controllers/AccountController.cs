using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Quiz.Domain.Contracts.IServices;
using Quiz.Domain.Exceptions;
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
        private readonly IConfiguration configuration;
        public AccountController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticatedResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Token(LoginModel login)
        {
            ClaimsIdentity identity;
            var user = await userService.GetUser(login);
            var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>();
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                identity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    user.Role);

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

                var response = new AuthenticatedResponse()
                {
                    Token = encodedJwt,
                    Username = identity.Name,
                    Role = identity.RoleClaimType
                };

                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid user request");
            }

            return Unauthorized();
        }

        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionResponse))]
        public async Task<ActionResult> Create(LoginModel login)
        {
            var account = await userService.Create(login);
            return Ok(account);
        }
    }
}

