using System;

namespace CloudEd.DAL.Persistence
{
    public class Question : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}