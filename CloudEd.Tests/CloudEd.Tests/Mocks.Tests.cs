using CloudEd.BLL.Core.Quiz.Models;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.DAL.Persistence;
using CloudEd.Tests.Mocks;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using CloudEd.DAL.Repositories;
using CloudEd.BLL.Helpers;

namespace CloudEd.Tests
{
    public class Mocks_Tests
    {


        [Fact]
        public void MockRepository_AddItem_ContainsIt()
        {
            // arrange
            IRepository<DummyPersistenceEntity, Guid> repo = new InMemoryRepository<DummyPersistenceEntity>();
            var item = new DummyPersistenceEntity();

            // act
            repo.Add(item);

            // assert
            Assert.Contains(repo.GetAll(), ent => ent.Id == item.Id);
        }

        [Fact]
        public void StubbedQuizCollection_ContainsQuestionsWithCorrectAnswers()
        {
            // arrange
            (var quiz, var questions) = QuizGenerator.GetQuizWithQuestions();
            var question = questions.RandomElement();

            // act
            var correctAnswer = question.CorrectAnswer;
            // assert
            Assert.Contains(question.Answers, a => a.Id == correctAnswer.Id);

        }

        private class DummyPersistenceEntity : IEntity<Guid>
        {
            public Guid Id { get; set; }
        }
    }
}
