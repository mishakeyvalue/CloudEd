using System;
using System.Collections.Generic;

namespace CloudEd.BLL.Core.Question.Models
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<AnswerViewModel> Answers { get; set; }
    }
}