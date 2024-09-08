namespace Exmaination_System
{
    public class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string questionText, int grade, bool correctAnswer)
        {
            QuestionText = questionText;
            QuestionGrade = grade;
            CorrectAnswer = correctAnswer;
        }

        public override bool CheckAnswer(string answer)
        {
            return (answer.ToLower() == "True" && CorrectAnswer) || (answer.ToLower() == "False" && !CorrectAnswer);
        }
    }
}
