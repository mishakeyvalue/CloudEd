using System;
using System.Collections.Generic;
using System.Text;

namespace CloudEd.BLL.Core.Quiz.Models
{
    public class QuizEditModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
