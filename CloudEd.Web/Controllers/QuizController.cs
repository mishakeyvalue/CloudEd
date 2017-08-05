using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.BLL.Core.Quiz.Models;
using CloudEd.BLL.Core.Question.Models;
using CloudEd.BLL.Core.Question.Services;

namespace CES.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("[action]")]
        public IEnumerable<QuizViewModel> LearningRoutine()
        {
            return _quizService.GetAll();
        }
    }
}
