using CloudEd.BLL.Core.Question.Models;
using System.Collections.Generic;

namespace CloudEd.BLL.Core.QuizWorkflow.Models
{
    public class QuizWorkflowResultModel
    {
        public IEnumerable<QuestionResultViewModel> SubmittedQuestions { get; set; }
    }
}
