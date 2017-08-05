using System.Collections.Generic;
using CloudEd.BLL.Core.Quiz.Models;

namespace CloudEd.BLL.Core.Quiz.Services
{
    public interface IQuizService
    {
        IEnumerable<QuizViewModel> GetAll();
    }
}