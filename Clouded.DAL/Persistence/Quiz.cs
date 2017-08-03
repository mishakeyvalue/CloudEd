using System;
using System.Collections.Generic;

namespace CloudEd.DAL.Persistence
{
    public class Quiz : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid> QuestionIds { get; set; }
    }
}
