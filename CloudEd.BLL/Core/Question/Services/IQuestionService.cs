using System.Collections.Generic;
using CloudEd.BLL.Core.Question.Models;

namespace CloudEd.BLL.Core.Question.Services
{
    public interface IQuestionService
    {
        IEnumerable<QuestionViewModel> GetAll();
    }
}