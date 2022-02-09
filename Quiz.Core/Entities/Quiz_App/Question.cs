using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Quiz.Core.Entities.Quiz_App
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Question1 { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual ICollection<Answer> Answer { get; set; }
    }
}
