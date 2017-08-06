using System;
using System.Collections.Generic;

namespace CloudEd.BLL.Core.QuizWorkflow.Models
{
    public class QuizWorkflowSubmitModel
    {
        public IEnumerable<WorkflowBit> Bits{ get; set; }

        public class WorkflowBit
        {
            public Guid QuestionId { get; set; }
            public Guid AnswerId { get; set; }
        }
    }
}
