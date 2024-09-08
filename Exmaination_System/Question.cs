namespace Exmaination_System
{
    
    public abstract class Question
    {
        public string? QuestionText { get; set; }
        public int QuestionGrade { get; set; }
        public abstract bool CheckAnswer(string answer);
    }
}
