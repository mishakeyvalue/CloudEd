using System;
using System.Collections.Generic;
using CloudEd.BLL.Core.Quiz.Models;

namespace CloudEd.BLL.Core.Quiz.Services
{
    public interface IQuizBackofficeService
    {
        IEnumerable<QuizEditModel> GetAll();
        void Save(QuizEditModel quiz);
        void Create(QuizCreateModel quiz);

        void SaveRelations(Guid quizId, IEnumerable<Guid> questionIds);
        void AddRelations(Guid quizId, IEnumerable<Guid> newQuestionIds);
        void RemoveRelations(Guid quizId, IEnumerable<Guid> questionIds);
    }
}