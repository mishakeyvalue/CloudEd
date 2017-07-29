using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CES.Models
{
    public class QuestionViewModel
    {
        public string Body { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
