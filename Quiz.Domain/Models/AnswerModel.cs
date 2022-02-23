using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Models
{
    public class AnswerModel
    {

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerName { get; set; }
        public bool Correct { get; set; }

        public string Question { get; set; }
    }
}
