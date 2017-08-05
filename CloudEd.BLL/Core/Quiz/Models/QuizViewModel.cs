using CloudEd.BLL.Core.Question.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudEd.BLL.Core.Quiz.Models
{
    public class QuizViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
