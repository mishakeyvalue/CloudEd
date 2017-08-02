using CloudEd.BLL.Core.Question.Models;
using System.Collections.Generic;

namespace CloudEd.BLL.Core.Question.Models
{
    public class QuestionCreateModel
    {
        public string Title { get; set; }
        public IEnumerable<AnswerCreateModel> Answers { get; set; }
        public AnswerCreateModel CorrectAnswer { get; set; }
    }
}