using CloudEd.BLL.Core.Quiz.Models;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.DAL.Persistence;
using CloudEd.Tests.Mocks;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using CloudEd.DAL.Repositories;
using CloudEd.BLL.Core.QuizWorkflow.Services;
using CloudEd.BLL.Helpers;
using CloudEd.BLL.Core.Question.Services;
using CloudEd.BLL.Core.QuizWorkflow.Models;
using static CloudEd.BLL.Core.QuizWorkflow.Models.QuizWorkflowSubmitModel;

namespace CloudEd.Tests
{
    public class QuizWorkflowService_Tests
    {
        private readonly IQuizWorkflowService _quizWorkflowService;
        private readonly IQuizService _quizService;
        private readonly InMemoryRepository<Quiz> _quizMockRepo;
        private readonly InMemoryRepository<Question> _questionMockRepo;

        public QuizWorkflowService_Tests()
        {
            (var quiz, var questions) = QuizGenerator.GetQuizWithQuestions();
            _quizMockRepo = new InMemoryRepository<Quiz>(quiz.ToEnumerableOfOne());
            _questionMockRepo = new InMemoryRepository<Question>(questions);

            var questionService= new QuestionService(_questionMockRepo);
            _quizWorkflowService = new QuizWorkflowService();
            _quizService = new QuizService(_quizMockRepo, questionService);
        }

        [Fact]
        public void Workflow_PickAllCorrect_ReturnsProperResult()
        {
            // arrange
            (var rawQuiz, var quizQuestions) = GetRawQuizWithQuestions();

            // act
            var takenQuiz = PickAllCorrect(rawQuiz, quizQuestions);
            var quizResult = _quizWorkflowService.Check(takenQuiz);

            // assert
            bool isAllAnsweredCorrectly = quizResult.SubmittedQuestions.All(q => q.IsAnsweredCorrectly);
            Assert.True(isAllAnsweredCorrectly);
        }

        private (Quiz, IEnumerable<Question>) GetRawQuizWithQuestions()
        {
            var quiz = _quizMockRepo.GetAll().First();
            var questions = _questionMockRepo.GetAll().Join(quiz.QuestionIds, q => q.Id, id => id, (q, id) => q);
            return (quiz, questions);
        }


        private QuizWorkflowSubmitModel PickAllCorrect(Quiz quiz, IEnumerable<Question> questions)
        {
            var answers = new List<WorkflowBit>();
            foreach (var question in questions)
            {
                var answer = new WorkflowBit()
                {
                    QuestionId = question.Id,
                    AnswerId = question.CorrectAnswer.Id
                };
            }
            return new QuizWorkflowSubmitModel()
            {
                Bits = answers
            };
        }

    }
}
