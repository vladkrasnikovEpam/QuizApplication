using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Models
{
    public class StatisticModel
    {
        public int Id { get; set; }
        public int Attemps { get; set; }
        public int AverageAnswersPercent { get; set; }
        public int RegisteredUsers { get; set; }
    }
}
