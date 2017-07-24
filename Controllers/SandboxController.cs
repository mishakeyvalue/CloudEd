using System;
using Microsoft.AspNetCore.Mvc;
using CES.Models;
using System.Collections.Generic;
using System.Linq;

namespace CES.Controllers
{
    public class SandboxController : Controller
    {
        private string CustomViewPath = "/Views/View.cshtm";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

      

        public IActionResult MyView()
        {
            return View(GetStubbedQuestion());
        }
    
        [HttpPost]
        public IActionResult MyView(AnswerEditViewModel answer)
        {
            return View(GetStubbedQuestion());
        }

        private QuestionViewModel GetStubbedQuestion()
        {
            IEnumerable<Answer> answers = new Answer[4];

            answers = answers.Select((_, i) => new Answer() { Id = 12, Body = "MountainDuck#" + i });

            return new QuestionViewModel()  
            {
                Body = "What is the name of the hottest animal in the Sahara?",
                Answers = answers
            };
        }

    }
}
