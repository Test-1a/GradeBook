/* using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            Console.WriteLine("In AddGrade!");
            grades.Add(grade);  // Storing the grade
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            var averageGrade = double.MinValue;

            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }
            result /= grades.Count;

            Console.WriteLine($"The highest grade is {highGrade}");
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The average grade is {result:N1}"); // Formatted as a Number with 1 decimal
        }

        private List<double> grades;    // This is a Field
        private string name;
    }
}
*/