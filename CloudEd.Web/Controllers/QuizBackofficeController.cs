using System;
using Microsoft.AspNetCore.Mvc;
using CloudEd.DAL.Repositories;
using CloudEd.DAL.Persistence;
using System.Collections.Generic;

namespace CES.Controllers
{
    [Route("api/[controller]")]
    public class QuizBackofficeController : Controller
    {
        private readonly IRepository<Quiz, Guid> _repository;

        public QuizBackofficeController(IRepository<Quiz, Guid> repository)
        {
            _repository = repository;
        }
        [HttpPost("[action]")]
        public IActionResult Quiz(Quiz quiz)
        {
            quiz.Id = Guid.NewGuid();
            _repository.Save(quiz);
            return Ok();
        }

        public IEnumerable<Quiz> Quizes()
        {
            var result = _repository.GetAll();
            return result;
        }
    }
}
