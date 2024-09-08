namespace Exmaination_System
{
    using System;
    using System.Collections.Generic;

    public class Teacher
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Teacher(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public List<Question> CreateExam()
        {
            List<Question> questions = new List<Question>();

            int numQuestions;
            while (true)
            {
                Console.WriteLine($"{Name}: Enter The Number Of Questions:");
                if (int.TryParse(Console.ReadLine(), out numQuestions) && numQuestions > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, Please Enter a Valid Number Of Questions.");
                }
            }

            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"Enter The Type Of Question {i + 1}\n ||1- for Multiple Choice||\n ||2- for True Or False||");
                Console.WriteLine("Please Enter Number 1 or 2\n");
                int questionType;
                while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
                {
                    Console.WriteLine("Try again,Invalid input. Please Enter:\n ||1- for Multiple Choice||\n ||2- for True Or False||");
                    Console.WriteLine("Please Enter Number 1 or 2\n");
                }

                Console.WriteLine($"Enter The Text for Question {i + 1}:");
                string questionText;
                while (true)
                {
                    questionText = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(questionText))
                    {
                        break;
                    }
                    Console.WriteLine("Question Text Cannot Be Empty. Please Enter a Valid Question");
                }

                Console.WriteLine($"Enter the Grade For Question {i + 1}");
                int grade;
                while (!int.TryParse(Console.ReadLine(), out grade) || grade <= 0)
                {
                    Console.WriteLine("Invalid input. Please Enter a Valid Grade");
                }

                if (questionType == 1)
                {
                 
                    Console.WriteLine("Enter The Number Of Choices");
                    int numChoices;
                    while (!int.TryParse(Console.ReadLine(), out numChoices) || numChoices <= 0)
                    {
                        Console.WriteLine("Invalid input. Please Enter a Valid Number Of Choices");
                    }

                    List<string> choices = new List<string>();
                    for (int j = 0; j < numChoices; j++)
                    {
                        Console.WriteLine($"Enter Choice {j + 1}:");
                        choices.Add(Console.ReadLine());
                    }

                    Console.WriteLine("Enter The Correct Answer:");
                    string correctAnswer = Console.ReadLine();

                    questions.Add(new MultipleChoiceQuestion(questionText, grade, choices, correctAnswer));
                }
                else if (questionType == 2)
                {
                   
                    Console.WriteLine("Enter The Correct Answer (True Or False):");
                    bool correctAnswer;
                    while (!bool.TryParse(Console.ReadLine(), out correctAnswer))
                    {
                        Console.WriteLine("Invalid input. Please Enter True Or False.");
                    }

                    questions.Add(new TrueFalseQuestion(questionText, grade, correctAnswer));
                }
            }

            return questions;
        }

        public void ConductExam(List<Question> questions)
        {
            foreach (var student in Students)
            {
                Console.WriteLine($"Starting Exam For {student.Name}");
                student.TakeExam(questions);
                student.ShowResults();
            }
        }
    }
}
