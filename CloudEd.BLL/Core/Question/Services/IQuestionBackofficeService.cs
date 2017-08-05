using CloudEd.BLL.Core.Question.Models;

namespace CloudEd.BLL.Core.Question.Services
{
    public interface IQuestionBackofficeService
    {
        QuestionEditModel Create(QuestionCreateModel question);
        QuestionEditModel Save(QuestionEditModel question);
    }
}