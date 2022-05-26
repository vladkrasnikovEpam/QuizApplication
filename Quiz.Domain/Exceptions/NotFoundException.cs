using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException() { }

        public NotFoundException(string message) : base(message)
        {

        }

        public override IActionResult GetContentResult()
        {
            return new NotFoundObjectResult(Message);
        }
    }
}
