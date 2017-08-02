using System;
using System.Collections.Generic;

namespace CloudEd.DAL.Persistence
{
    public class Question : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public Answer CorrectAnswer { get; set; }

        public class Answer
        {
            public Guid Id { get; set; }
            public string Body { get; set; }

        }
    }
}