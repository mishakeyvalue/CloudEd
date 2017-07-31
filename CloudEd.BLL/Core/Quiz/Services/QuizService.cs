using CloudEd.DAL.Repositories;
using CloudEd.DAL.Persistence;
using System;

namespace CloudEd.BLL.Core.Quiz.Services
{
    public class QuizService
    {
        private readonly IRepository<DAL.Persistence.Quiz, Guid> _quizRepository;

        public QuizService(IRepository<CloudEd.DAL.Persistence.Quiz, Guid> quizRepository)
        {
            _quizRepository = quizRepository;
        }
    }
}
