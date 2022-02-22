using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Models
{
    public class TopicPaginationModel
    {
        public List<TopicModel> Topic { get; set; }
        public PaginationModel Pagination { get; set; }
    }
}
