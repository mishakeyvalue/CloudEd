using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.BLL.Core.Quiz.Models;
using CloudEd.BLL.Core.Question.Models;
using CloudEd.BLL.Core.Question.Services;
using CloudEd.BLL.Core.QuizWorkflow.Models;
using CloudEd.BLL.Core.QuizWorkflow.Services;

namespace CES.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly IQuizService _quizService;
        private readonly IQuizWorkflowService _quizWorkflowService;

        public QuizController(
            IQuizService quizService,
            IQuizWorkflowService quizWorkflowService)
        {
            _quizService = quizService;
            _quizWorkflowService = quizWorkflowService;
        }

        [HttpGet("[action]")]
        public IEnumerable<QuizViewModel> LearningRoutine()
        {
            return _quizService.GetAll();
        }

        [HttpPost("[action]")]
        public QuizWorkflowResultModel LearningRoutine([FromBody] QuizWorkflowSubmitModel submittedQuiz)
        {
            return _quizWorkflowService.Check(submittedQuiz);
        }
    }
}
