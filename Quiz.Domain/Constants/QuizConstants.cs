using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Constants
{
    public class QuizConstants
    {
        public const int NumberOfTopicsPerPage = 10;
        public const string TopicPageUrl = "https://localhost:5001/api/topic/page/";
        public static string EntityNotFound = "{0} with id = {1} is not found";
        public static string UnhandledException = "Unhandled exception : {0}";
    }
}
