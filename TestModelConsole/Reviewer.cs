using System.Collections.Generic;
using TestModel.Common;

namespace TestModelConsole
{
    public class Reviewer
    {
        public int UserId { get; set; }
        public string WorkFlowStageName { get; set; }
        public int WorkFlowStageLevel { get; set; }
        //public List<string> Roles { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string Comment { get; set; }

        public List<ReviewerQuestionAnswer> ReviewerQuestionAnswer { get; set; }

    }
}