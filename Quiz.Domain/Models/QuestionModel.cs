using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string QuestionName { get; set; }

        public string Topic { get; set; }
        public List<AnswerModel> Answer { get; set; }
    }
}
