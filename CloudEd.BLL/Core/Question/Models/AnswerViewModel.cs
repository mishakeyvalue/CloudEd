using System;

namespace CloudEd.BLL.Core.Question.Models
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Guid QuestionId { get; set; }
    }
}