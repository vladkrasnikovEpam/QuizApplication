using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Core.Entities.Quiz_App
{
    public partial class Statistic
    {
        public int Id { get; set; }
        public int Attemps { get; set; }
        public int AverageAnswersPercent { get; set; }
        public int RegisteredUsers { get; set; }
    }
}
