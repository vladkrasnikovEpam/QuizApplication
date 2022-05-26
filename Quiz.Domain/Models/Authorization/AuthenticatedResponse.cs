using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Models.Authorization
{
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
    }
}
