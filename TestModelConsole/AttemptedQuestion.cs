using System.Collections.Generic;
using TestModel.Common;

namespace TestModelConsole
{
    public class AttemptedQuestion
    {
        public int QuestionId { get; set; }
        public string QuestionCategory { get; set; }
        public List<CandidateQuestionAnswer> QuestionAnswers { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string WorkFlowId { get; set; }

        public List<Reviewer> Reviewers { get; set; }

        
    }
}