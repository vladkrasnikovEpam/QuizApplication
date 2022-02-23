using Quiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Parameters
{
    public class TopicParameters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<QuestionModel> Question { get; set; }
    }
}
