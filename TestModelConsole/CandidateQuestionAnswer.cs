using System.Collections.Generic;

namespace TestModelConsole
{
    public class CandidateQuestionAnswer : QuestionAnswerBase
    {
        public string CorrectAnswer { get; set; }
        public int ReviewerScore { get; set; }
        public string ReviewerComment { get; set; }
        public string ReviewerUserId { get; set; }
    }
}