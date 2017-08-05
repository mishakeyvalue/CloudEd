using System;

namespace CloudEd.BLL.Core.Quiz.Services
{
    public interface IQuizToQuestionRelationService
    {
        void AddQuestion(Guid quizId, Guid questionId);
        void RemoveQuestion(Guid quizId, Guid questionId);
    }
}