using CloudEd.DAL.Repositories;
using CloudEd.DAL.Persistence;
using System;
using CloudEd.BLL.Core.Quiz.Models;
using System.Collections.Generic;
using System.Linq;

namespace CloudEd.BLL.Core.Quiz.Services
{
    public class QuizBackofficeService : IQuizBackofficeService
    {
        private readonly IRepository<DAL.Persistence.Quiz, Guid> _quizRepository;

        public QuizBackofficeService(IRepository<CloudEd.DAL.Persistence.Quiz, Guid> quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public IEnumerable<QuizEditModel> GetAll()
        {
            return _quizRepository.GetAll().Select(MapQuizToEditModel);
        }

        public void Save(QuizEditModel quiz)
        {
            // TODO : refactor this mess p_0
            var persistenceEntity =_quizRepository.Get(quiz.Id);
            persistenceEntity.Title = quiz.Title;
            persistenceEntity.Description = quiz.Description;
            _quizRepository.Save(persistenceEntity);
        }

        private QuizEditModel MapQuizToEditModel(DAL.Persistence.Quiz quiz)
        {
            return new QuizEditModel()
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Description = quiz.Description
            };
        }
    }
}
