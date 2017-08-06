using CloudEd.BLL.Core.Quiz.Models;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.DAL.Persistence;
using CloudEd.Tests.Mocks;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using CloudEd.DAL.Repositories;
using static CloudEd.DAL.Persistence.Question;
using CloudEd.BLL.Helpers;

namespace CloudEd.Tests
{
    public class QuizBackofficeService_Tests
    {
        private readonly IQuizBackofficeService _quizBackofficeService;
        private Question stubQuestionOutsideQuiz = QuizGenerator.GenerateChickenQuestion();

        public QuizBackofficeService_Tests()
        {
            (var quiz, var questions) = QuizGenerator.GetQuizWithQuestions();
            var quizMockRepo = new InMemoryRepository<Quiz>(quiz.ToEnumerableOfOne());
            var questionMockRepo = new InMemoryRepository<Question>(questions.Append(stubQuestionOutsideQuiz));

            var service = new QuizBackofficeService(quizMockRepo, questionMockRepo);
            _quizBackofficeService = service;
        }        

        [Fact]
        public void AddQuestion_RelationAdded()
        {
            // arrange
            QuizEditModel quiz = _quizBackofficeService.GetAll().First();
            Guid dummyQuestionId = stubQuestionOutsideQuiz.Id;

            // act
            _quizBackofficeService.AddQuestion(quiz.Id, dummyQuestionId);

            //assert
            QuizEditModel savedQuiz = _quizBackofficeService.GetAll().First(q => q.Id == quiz.Id);
            Assert.Contains(savedQuiz.Questions, q => q.Id == dummyQuestionId);
        }
    }
}
