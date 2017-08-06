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

namespace CloudEd.Tests
{
    public class QuizBackofficeService_Tests
    {
        private readonly IQuizBackofficeService _quizBackofficeService;
        private Question StubQuestion;

        public QuizBackofficeService_Tests()
        {
            var quizMockRepo = new InMemoryRepository<Quiz>();
            AddStubQuizes(quizMockRepo);
            var questionMockRepo = new InMemoryRepository<Question>();
            AddStubQuestions(questionMockRepo);
            var service = new QuizBackofficeService(quizMockRepo, questionMockRepo);
            _quizBackofficeService = service;
        }

        #region Helpers
        private void AddStubQuizes(InMemoryRepository<Quiz> quizMockRepo)
        {
            var quiz = new Quiz()
            {
                Id = Guid.NewGuid(),
                Title = "Stub",
                Description = "This is my stub",
                QuestionIds = GenerateGuids(12)
            };
            quizMockRepo.Add(quiz);
        }

        private IEnumerable<Guid> GenerateGuids(int n)
        {
            var arr = new Guid[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Guid.NewGuid();
            }
            return arr;
        }
        private void AddStubQuestions(InMemoryRepository<Question> questionMockRepo)
        {
            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = Guid.NewGuid(),
                    Body = "42"
                },

                new Answer()
                {
                    Id = Guid.NewGuid(),
                    Body = "455"
                }
            };
            StubQuestion = new Question()
            {
                Id = Guid.NewGuid(),
                Title = "Stubbed question",
                Answers = answers,
                CorrectAnswer = answers.First()
            };
            questionMockRepo.Add(StubQuestion);
        }
        #endregion

        [Fact]
        public void AddQuestion_RelationAdded()
        {
            // arrange
            QuizEditModel quiz = _quizBackofficeService.GetAll().First();
            Guid dummyQuestionId = StubQuestion.Id;

            // act
            _quizBackofficeService.AddQuestion(quiz.Id, dummyQuestionId);

            //assert
            QuizEditModel savedQuiz = _quizBackofficeService.GetAll().First(q => q.Id == quiz.Id);
            Assert.Contains(savedQuiz.Questions, q => q.Id == dummyQuestionId);
        }
    }
}
