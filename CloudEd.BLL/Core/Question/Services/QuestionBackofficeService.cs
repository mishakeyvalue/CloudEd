using CloudEd.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using CloudEd.DAL.Persistence;
using CloudEd.BLL.Core.Question.Models;
using System.Linq;
using static CloudEd.DAL.Persistence.Question;
using CloudEd.BLL.Core.Quiz.Services;

namespace CloudEd.BLL.Core.Question.Services
{
    public class QuestionBackofficeService : IQuestionBackofficeService
    {
        private readonly IRepository<DAL.Persistence.Question, Guid> _questionRepository;

        public QuestionBackofficeService(IRepository<DAL.Persistence.Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public QuestionEditModel Save(QuestionEditModel question)
        {
            var persitstenceEntity = _questionRepository.Get(question.Id);
            persitstenceEntity = MapQuestionEditModelToPersistence(question);
            _questionRepository.Save(persitstenceEntity);
            return question;
        }

        private DAL.Persistence.Question MapQuestionEditModelToPersistence(QuestionEditModel question)
        {
            return new DAL.Persistence.Question()
            {
                Id = question.Id,
                Title = question.Title,
                Answers = question.Answers.Select(MapAnswerEditModelToPersistence),
                CorrectAnswer = MapAnswerEditModelToPersistence(question.Answers.First(q => q.IsCorrect))
            };
        }
        private Answer MapAnswerEditModelToPersistence(AnswerEditModel answer)
        {
            return new Answer()
            {
                Id = answer.Id,
                Body = answer.Body
            };
        }

        public QuestionEditModel Create(QuestionCreateModel question)
        {
           Guid id = _questionRepository.Add(MapQuestionCreateModelToPersistence(question));
            return QuizBackofficeService.MapQuestionPersistnenceToEditModel(_questionRepository.Get(id));
        }

        private DAL.Persistence.Question MapQuestionCreateModelToPersistence(QuestionCreateModel question)
        {
            var answerTuple = ParseAnswers(question);
            return new DAL.Persistence.Question()
            {
                Id = Guid.NewGuid(),
                Title = question.Title,
                Answers = answerTuple.answers,
                CorrectAnswer = answerTuple.correctAnswer
            };
        }

        private (IEnumerable<Answer> answers, Answer correctAnswer) ParseAnswers(QuestionCreateModel question)
        {
            var answers = new List<Answer>();
            Answer correctAnswer = null;
            foreach (var createModel in question.Answers)
            {
                var parsedAnswer = MapAnswerCreateModelToPersistence(createModel);
                answers.Add(parsedAnswer);
                if (createModel.IsCorrect)
                    correctAnswer = parsedAnswer;
            }
            return (answers, correctAnswer);
        }

        private Answer MapAnswerCreateModelToPersistence(AnswerCreateModel answer)
        {
            return new Answer()
            {
                Id = Guid.NewGuid(),
                Body = answer.Body
            };
        }
    }
}

