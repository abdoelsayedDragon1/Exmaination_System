namespace Exmaination_System
{
    using System;
    using System.Collections.Generic;

    
    public class MultipleChoiceQuestion : Question
    {
        public List<string> Choices { get; set; }
        public string CorrectAnswer { get; set; }

        public MultipleChoiceQuestion(string questionText, int grade, List<string> choices, string correctAnswer)
        {
            QuestionText = questionText;
            QuestionGrade = grade;
            Choices = choices;
            CorrectAnswer = correctAnswer;
        }

        public override bool CheckAnswer(string answer)
        {
            return answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
