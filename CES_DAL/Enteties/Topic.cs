using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CES_DAL.Enteties
{
    public class Topic
    {
        [Key]
        public string TopicTitle { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}