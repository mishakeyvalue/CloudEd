using CloudEd.BLL.Core.Question.Models;
using System;
using System.Collections.Generic;

namespace CloudEd.BLL.Core.Quiz.Models
{
    public class QuizEditModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<QuestionEditModel> Questions{ get; set; }
    }
}
