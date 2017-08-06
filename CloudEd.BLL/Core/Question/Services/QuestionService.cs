using CloudEd.BLL.Core.Question.Models;
using CloudEd.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudEd.BLL.Core.Question.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<DAL.Persistence.Question, Guid> _questionRepository;
        public QuestionService(IRepository<DAL.Persistence.Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public IEnumerable<QuestionViewModel> GetAll()
        {
            var result = _questionRepository.GetAll()
                .Select(MapQuestionPersistenceToViewModel);
            return result;
        }

        public static QuestionViewModel MapQuestionPersistenceToViewModel(DAL.Persistence.Question question)
        {
            var answers = question.Answers.Select(a =>
                new AnswerViewModel()
                {
                    Id = a.Id,
                    Body = a.Body,
                    QuestionId = question.Id
                });
            var result = new QuestionViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                Answers = answers
            };
            return result;
        }

    }
}
