using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.BLL.Core.Quiz.Models;

namespace CES.Controllers
{
    [Route("api/[controller]")]
    public class BackofficeController : Controller
    {
        private readonly IQuizBackofficeService _quizBackofficeService;

        public BackofficeController(IQuizBackofficeService quizBackofficeService)
        {
            _quizBackofficeService = quizBackofficeService;
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
    }
}
