using System.Collections.Generic;
using TestModel.Common;

namespace TestModel.DataAccess.Objects
{
    public class ReviewerDto
    {
        public int UserId { get; set; }
        public string WorkFlowStageName { get; set; }
        public int WorkFlowStageLevel { get; set; }
        //public List<string> Roles { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string Comment { get; set; }

        public List<ReviewerQuestionAnswerDto> ReviewerQuestionAnswer { get; set; }
    }
}