using CloudEd.DAL.Repositories;
using CloudEd.DAL.Persistence;
using System;
using CloudEd.BLL.Core.Quiz.Models;
using System.Collections.Generic;
using System.Linq;
using CloudEd.BLL.Core.Question.Services;

namespace CloudEd.BLL.Core.Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly IRepository<DAL.Persistence.Quiz, Guid> _quizRepository;
        private readonly IQuestionService _questionService;

        public QuizService(
            IRepository<CloudEd.DAL.Persistence.Quiz, Guid> quizRepository,
            IQuestionService questionService)
        {
            _quizRepository = quizRepository;
            _questionService = questionService;
        }

        public IEnumerable<QuizViewModel> GetAll()
        {
            var quizes = _quizRepository.GetAll();
            var allQuestions = _questionService.GetAll(); // Refactor this awfull architechture!
            var result = quizes.Select(q =>
               new QuizViewModel()
               {
                   Id = q.Id,
                   Title = q.Title,
                   Description = q.Description,
                   Questions = allQuestions.Join(q.QuestionIds, qu => qu.Id, id => id, (qu, id) => qu)
                    
                });
            return result;
        }
        
    }
}
