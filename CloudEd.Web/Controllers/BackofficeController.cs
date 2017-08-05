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
    public class BackofficeController : Controller
    {
        private readonly IQuizBackofficeService _quizBackofficeService;
        private readonly IQuestionBackofficeService _questionBackofficeService;

        public BackofficeController(
            IQuizBackofficeService quizBackofficeService,
            IQuestionBackofficeService questionBackofficeService)
        {
            _quizBackofficeService = quizBackofficeService;
            _questionBackofficeService = questionBackofficeService;
        }

        [HttpGet("[action]")]
        public IEnumerable<QuizEditModel> Quiz()
        {
            var result = _quizBackofficeService.GetAll();
            return result;
        }

        [HttpPut("[action]")]
        public IActionResult Quiz([FromBody] QuizEditModel editModel)
        {
            _quizBackofficeService.Save(editModel);
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult Quiz([FromBody] QuizCreateModel createModel)
        {
            _quizBackofficeService.Create(createModel);
            return Ok();
        }

        [HttpGet("[action]")]
        public IEnumerable<QuizEditModel> Question()
        {
            var result = _quizBackofficeService.GetAll();
            return result;
        }

        [HttpPut("[action]")]
        public QuestionEditModel Question([FromBody] QuestionEditModel editModel)
        {
            var result = _questionBackofficeService.Save(editModel);
            return result;
        }

        [HttpPost("[action]")]
        public QuestionEditModel Question([FromBody] QuestionCreateModel createModel)
        {
            var result = _questionBackofficeService.Create(createModel);
            return result;
        }
    }
}
