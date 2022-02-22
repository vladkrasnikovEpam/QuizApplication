﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Core.Entities.Quiz_App
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
