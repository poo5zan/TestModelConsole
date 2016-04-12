namespace TestModel.DataAccess.Objects
{
    public class CandidateQuestionAnswerDto : QuestionAnswerBaseDto
    {
        public string CorrectAnswer { get; set; }
        public int ReviewerScore { get; set; }
        public string ReviewerComment { get; set; }
        public string ReviewerUserId { get; set; }
    }
}