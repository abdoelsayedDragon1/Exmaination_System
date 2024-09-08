namespace Exmaination_System
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            bool isExamCreated = false;

            while (true)  
            {
                
                Console.WriteLine("Are you a Teacher or a Student?");
                Console.WriteLine("||T- for Teacher|| \n" + "||S- for Student||");
                Console.WriteLine("Please Enter char T or S");
                char userType = char.Parse(Console.ReadLine().ToUpper());

                if (userType == 'T')
                {
                    Console.WriteLine("Enter Teacher's name:");
                    string? teacherName = Console.ReadLine();
                    Teacher teacher = new Teacher(teacherName);

                    List<Question> examQuestions = teacher.CreateExam();


                    Console.WriteLine("How Many Students Are taking The Exam?");
                    int numStudents = int.Parse(Console.ReadLine());

                    for (int i = 0; i < numStudents; i++)
                    {
                        Console.WriteLine($"Enter Student {i + 1}'s Name:");
                        string? studentName = Console.ReadLine();
                        Student student = new Student(studentName);

               
                        teacher.AddStudent(student);
                    }
                    teacher.ConductExam(examQuestions);

                    isExamCreated = true; 
                }
                else if (userType == 'S')
                {
                    if (!isExamCreated)
                    {
                        
                        Console.WriteLine("Please Wait For a Teacher To Set Up The Exam");
                    }
                    else
                    {
                        Console.WriteLine("The Exam Is Ready, but Only The Teacher Can Start It");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please Enter:");
                    Console.WriteLine("Please Enter char ||T or S||\n");

                }
            }
        }
    }
}
