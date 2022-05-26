using Microsoft.AspNetCore.Mvc;
using System;

namespace Quiz.Domain.Exceptions
{
    public abstract class CustomException : Exception
    {
        public CustomException() { }

        public CustomException(string message) : base(message)
        {

        }

        public abstract IActionResult GetContentResult();
    }
}