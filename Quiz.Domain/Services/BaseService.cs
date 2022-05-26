using Microsoft.Extensions.Logging;
using Quiz.Domain.Constants;
using Quiz.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly ILogger<BaseService> _logger;

        protected BaseService(ILogger<BaseService> logger)
        {
            _logger = logger;
        }

        protected void ThrowNotFoundException(int id, string entityName)
        {
            var message = string.Format(QuizConstants.EntityNotFound, entityName, id);

            _logger.LogWarning(message);

            throw new NotFoundException(message);
        }

        //protected void ThrowNotFoundException(string entityName)
        //{
        //    var message = string.Format(QuizConstants.EntityWithoutIdNotFound, entityName);

        //    _logger.LogWarning(message);

        //    throw new NotFoundException(message);
        //}

        protected void ThrowBadRequestException(string message)
        {
            _logger.LogWarning(message);

            throw new Exception(message);
        }

        //protected void ThrowUnauthorizedException(string message)
        //{
        //    _logger.LogWarning(message);

        //    throw new UnauthorizedException(message);
        //}
    }
}
