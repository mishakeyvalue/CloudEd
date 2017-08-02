using System;

namespace CloudEd.BLL.Core.Question.Models
{
    public class AnswerEditModel
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public bool IsCorrect { get; set; }
    }
}