using System.Collections.Generic;
using TestModel.Common;

namespace TestModel.DataAccess.Objects
{
    public class AttemptedQuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionCategory { get; set; }
        public List<CandidateQuestionAnswerDto> QuestionAnswers { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string WorkFlowId { get; set; }

        public List<ReviewerDto> Reviewers { get; set; }
    }
}