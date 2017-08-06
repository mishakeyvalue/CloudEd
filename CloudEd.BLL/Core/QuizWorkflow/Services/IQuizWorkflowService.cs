using CloudEd.BLL.Core.QuizWorkflow.Models;

namespace CloudEd.BLL.Core.QuizWorkflow.Services
{
    public interface IQuizWorkflowService
    {
        QuizWorkflowResultModel Check(QuizWorkflowSubmitModel submitModel);
    }
}
