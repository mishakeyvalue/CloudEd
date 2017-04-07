using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CES_BLL
{
    public class Quiz
    {
        [Key]
        public string QuizID { get; set; }
        public string Title { get; set; }
        public string Desctiption { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new HashSet<Question>();
        }
    }
}
