using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole
{
    public abstract class QuestionAnswerBase
    {
        public int QuestionAnswerId { get; set; }
        public int AttemptedQuestionId { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public List<string> AnswerOptions { get; set; }       
        public string UserEnteredAnswer { get; set; }
    }
}
