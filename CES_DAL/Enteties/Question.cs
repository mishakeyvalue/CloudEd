using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CES_DAL.Enteties
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }

        public Dictionary<string, bool> Answers { get; set; } = new Dictionary<string, bool>();

        public virtual Topic Topic { get; set; }
    }
}