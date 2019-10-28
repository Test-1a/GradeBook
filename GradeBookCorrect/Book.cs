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

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':           //'A' is a constant value
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                default:            // runs if not A, B or C
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)   // grade is 0 - 100
            {
                grades.Add(grade);  // Storing the grade
            }
            else
            {
                //Console.WriteLine("Invalid Value!");

                //Throwing an exception due to the wrong value of a parameter
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
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

            //var index = 0;
            //do
            //{
            //    result.Low = Math.Min(grades[index], result.Low);
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index += 1;
            //} while (index < grades.Count);
            //result.Average /= grades.Count;

            //var index = 0;
            //while (index < grades.Count);
            //{
            //    result.Low = Math.Min(grades[index], result.Low);
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index += 1;
            //};
            //result.Average /= grades.Count;

            //for(var index = 0; index < grades.Count; index += 1)
            //{
            //    result.Low = Math.Min(grades[index], result.Low);
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index += 1;
            //}
            //result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:  // C# ver 7
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        private List<double> grades;    // This is a Field
        public string Name;
    }
}

