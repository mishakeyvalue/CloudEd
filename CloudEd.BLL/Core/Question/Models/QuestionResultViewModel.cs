using System;
using System.Collections.Generic;
using System.Text;

namespace CloudEd.BLL.Core.Question.Models
{
    public class QuestionResultViewModel : QuestionViewModel
    {
        public bool IsAnsweredCorrectly {
            get => CorrectAnswer.Id == TakenAnswer.Id;
        }
        public AnswerViewModel TakenAnswer { get; set; }
        public AnswerViewModel CorrectAnswer { get; set; }
    }
}
