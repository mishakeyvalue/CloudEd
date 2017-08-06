using System;
using System.Collections.Generic;
using System.Text;

namespace CloudEd.BLL.Core.Question.Models
{
    public class QuestionResultViewModel : QuestionViewModel
    {
        public bool IsAnsweredCorrectly {
            get => CorrectAnswerId == TakenAnswerId;
        }
        public Guid TakenAnswerId { get; set; }
        public Guid CorrectAnswerId { get; set; }
    }
}
