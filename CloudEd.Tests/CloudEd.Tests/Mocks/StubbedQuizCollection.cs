using CloudEd.DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CloudEd.DAL.Persistence.Question;

namespace CloudEd.Tests.Mocks
{
    static class StubbedQuizCollection
    {
        private static Random r = new Random(DateTime.Now.Millisecond);

        public static IEnumerable<Quiz> GetAll()
        {
            var quizes = new List<Quiz>()
            {
                ChickenQuiz
            }; ;

            return quizes;
        }

        private static Quiz ChickenQuiz {
            get {
                var quiz = new Quiz()
                {
                    Id = Guid.NewGuid(),
                    Title = "Chicken quiz",
                    Description = "My quiz about chickens for unit testing)",
                    QuestionIds = GetChickenQuestions(12).Select(q => q.Id)
                };
                return quiz;
            }
        }

        private static IEnumerable<Question> GetChickenQuestions(int n)
        {
            var arr = new Question[n];

            for (int i = 0; i < n; i++)
                arr[i] = GenerateChickenQuestion();

            return arr;
        }

        private static Question GenerateChickenQuestion()
        {
            var answers = GenerateChickenAnswers();
            return new Question()
            {
                Id = Guid.NewGuid(),
                Title = r.Next().ToString(),
                Answers = answers,
                CorrectAnswer = RandomAnswer(answers)

            };
        }

        private static IEnumerable<Answer> GenerateChickenAnswers()
        {
            var answersArray = new Answer[r.Next(2, 5)];
            for (int i = 0; i < answersArray.Length; i++)
            {
                answersArray[i] = new Answer()
                {
                    Id = Guid.NewGuid(),
                    Body = r.Next().ToString()
                };
            }
            return answersArray;
        }

        private static Answer RandomAnswer(IEnumerable<Answer> answers)
        {
            return answers.ElementAt(r.Next(0, answers.Count()));
        }
    }
}
