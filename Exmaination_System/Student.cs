namespace Exmaination_System
{
    using System;
    using System.Collections.Generic;
    public class Student
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<string> Answers { get; set; }
        public int TotalScore { get; set; } = 0;

        public Student(string name)
        {
            Name = name;
            Questions = new List<Question>();
            Answers = new List<string>();
        }

        public void TakeExam(List<Question> questions)
        {
            Questions = questions;
            foreach (var question in Questions)
            {
                Console.WriteLine(question.QuestionText);
                string? answer = Console.ReadLine();
                Answers.Add(answer);
            }
        }
        public void ShowResults()
        {
            int correct = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i].CheckAnswer(Answers[i]))
                {
                    correct++;
                    TotalScore += Questions[i].QuestionGrade;
                }
            }
            Console.WriteLine($"{Name}: you Answered {correct} Out Of {Questions.Count} Questions Correctly");
            Console.WriteLine($"YOUR TOTAL SCORE IS: {TotalScore}");
        }
    }
}
