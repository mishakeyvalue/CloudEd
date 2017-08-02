using CloudEd.BLL.Core.Question.Models;

namespace CloudEd.BLL.Core.Question.Services
{
    public interface IQuestionBackofficeService
    {
        void Create(QuestionCreateModel question);
        void Save(QuestionEditModel question);
    }
}