using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Exceptions
{
    public class BadRequestException : CustomException
    {
        public BadRequestException() { }

        public BadRequestException(string message) : base(message)
        {

        }

        public override IActionResult GetContentResult()
        {
            return new BadRequestObjectResult(new ExceptionResponse()
            {
                Message = Message
            });
        }
    }
}
