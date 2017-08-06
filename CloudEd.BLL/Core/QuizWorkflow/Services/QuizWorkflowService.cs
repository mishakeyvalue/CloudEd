using System;
using System.Collections.Generic;
using CloudEd.BLL.Core.QuizWorkflow.Models;
using CloudEd.DAL.Repositories;
using CloudEd.BLL.Core.Question.Models;
using System.Linq;
using static CloudEd.BLL.Core.QuizWorkflow.Models.QuizWorkflowSubmitModel;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.BLL.Core.Question.Services;

namespace CloudEd.BLL.Core.QuizWorkflow.Services
{
    public class QuizWorkflowService : QuizService, IQuizWorkflowService
    {
        private readonly IRepository<DAL.Persistence.Question, Guid> _questionRepository;

        public QuizWorkflowService(
            IRepository<DAL.Persistence.Question, Guid> questionRepository,
            IRepository<CloudEd.DAL.Persistence.Quiz, Guid> quizRepository,
            IQuestionService questionService)
            : base(quizRepository, questionService)
        {
            _questionRepository = questionRepository;
        }
        public QuizWorkflowResultModel Check(QuizWorkflowSubmitModel submitModel)
        {
            var result = new QuizWorkflowResultModel()
            {
                SubmittedQuestions = CheckAnswers(submitModel.Bits)
            };

            return result;
        }

        private IEnumerable<QuestionResultViewModel> CheckAnswers(IEnumerable<WorkflowBit> bits)
        {
            var questions = GetRelevantQuestions(bits);
            var result = new List<QuestionResultViewModel>(bits.Count());

            foreach (var bit in bits)
            {
                var question = questions.First(q => q.Id == bit.QuestionId);
                result.Add(CheckOneAnswer(bit, question));
            }

            return result;

            QuestionResultViewModel CheckOneAnswer(WorkflowBit answer, DAL.Persistence.Question question)
            {
                var resultViewModel = MapQuestionPersistenceToResultViewModel(question);
                resultViewModel.CorrectAnswerId = resultViewModel.Answers.First(a => a.Id == question.CorrectAnswer.Id).Id;
                resultViewModel.TakenAnswerId = resultViewModel.Answers.FirstOrDefault(a => a.Id == answer.AnswerId)?.Id ?? Guid.Empty;
                return resultViewModel;
            }
        }


        public static QuestionResultViewModel MapQuestionPersistenceToResultViewModel(DAL.Persistence.Question question)
        {
            var answers = question.Answers.Select(a =>
                new AnswerViewModel()
                {
                    Id = a.Id,
                    Body = a.Body,
                    QuestionId = question.Id
                });
            var result = new QuestionResultViewModel()
            {
                Id = question.Id,
                Title = question.Title,
                Answers = answers
            };
            return result;
        }

        private IEnumerable<DAL.Persistence.Question> GetRelevantQuestions(IEnumerable<WorkflowBit> bits)
        {
            var result = _questionRepository.GetAll()
                .Join(bits, q => q.Id, bit => bit.QuestionId, (q, bit) => q);
            return result;
        }
    }
}
