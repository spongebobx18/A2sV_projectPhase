using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StudentGradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student Grade Calculator!");

  
            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();

      
            Console.Write("Enter the number of subjects: ");
            int numSubjects;
            while (!int.TryParse(Console.ReadLine(), out numSubjects) || numSubjects <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of subjects.");
                Console.Write("Enter the number of subjects: ");
            }

            Dictionary<string, double> subjectGrades = new Dictionary<string, double>();

         
            for (int i = 0; i < numSubjects; i++)
            {
                Console.Write($"Enter the name of subject {i + 1}: ");
                string subjectName = Console.ReadLine();

                double grade;
                do /*" this runs the code at least once"*/
                {
                    Console.Write($"Enter the grade for {subjectName}: ");
                } while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100);/*"this takes the input and tries to convert it to the double. It returns a boolean value which tells it whether to store or not "*/

                subjectGrades.Add(subjectName, grade);
            }

            // Calculate the average grade
            double totalGrade = 0;
            //"the foreach is used to iterate"
            foreach (var grade in subjectGrades.Values)
            {
                totalGrade += grade;
            }
            double averageGrade = totalGrade / numSubjects;


            Console.WriteLine($"\nStudent Name: {studentName}");
            Console.WriteLine("Subject Grades:");
            foreach (var kvp in subjectGrades)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"Average Grade: {averageGrade:F2}");

            Console.ReadLine();
        }
    }
}
