using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            Console.WriteLine("In AddGrade!");
            grades.Add(grade);  // Storing the grade
        }

        public Statistics GetStatistics()
        {
            //var result = 0.0;
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            

            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;    // This is a Field
        public string Name;
    }
}
