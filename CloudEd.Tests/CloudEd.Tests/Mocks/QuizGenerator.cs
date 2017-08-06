using CloudEd.BLL.Helpers;
using CloudEd.DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CloudEd.DAL.Persistence.Question;

namespace CloudEd.Tests.Mocks
{
    static class QuizGenerator
    {
        private static Random r = new Random(DateTime.Now.Millisecond);

        public static (Quiz, IEnumerable<Question>) GetQuizWithQuestions()
        {
            var questions = GetChickenQuestions(123);
            var quiz = GetChickenQuiz(questions);
            return (quiz, questions);
        }

        private static Quiz GetChickenQuiz(IEnumerable<Question> questions)
        {
            var quiz = new Quiz()
            {
                Id = Guid.NewGuid(),
                Title = "Chicken quiz",
                Description = "My quiz about chickens for unit testing)",
                QuestionIds = questions.Select(q => q.Id)
            };
            return quiz;
        }

        private static IEnumerable<Question> GetChickenQuestions(int n)
        {
            var arr = new Question[n];

            for (int i = 0; i < n; i++)
                arr[i] = GenerateChickenQuestion();

            return arr;
        }

        public static Question GenerateChickenQuestion()
        {
            var answers = GenerateChickenAnswers();
            return new Question()
            {
                Id = Guid.NewGuid(),
                Title = r.Next().ToString(),
                Answers = answers,
                CorrectAnswer = answers.RandomElement()
            };
        }

        private static IEnumerable<Answer> GenerateChickenAnswers()
        {
            var answersArray = new Answer[r.Next(2, 5)];
            for (int i = 0; i < answersArray.Length; i++)
                answersArray[i] = new Answer() { Id = Guid.NewGuid(), Body = r.Next().ToString() };

            return answersArray;
        }
    }
}
