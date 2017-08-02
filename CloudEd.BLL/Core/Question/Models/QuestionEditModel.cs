using System;
using System.Collections.Generic;

namespace CloudEd.BLL.Core.Question.Models
{
    public class QuestionEditModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<AnswerEditModel> Answers { get; set; }
        public AnswerEditModel CorrectAnswer { get; set; }
    }
}