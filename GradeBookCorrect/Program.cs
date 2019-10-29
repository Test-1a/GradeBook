using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott´s Grade Book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);
            }

 
            var stats = book.GetStatistics();

            //book.Name = "Johan";  //can ONLY be used if the setter is public
            Console.WriteLine($"For the book named {book.Name}");   //uses the "getter" of the name-property
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The average grade is {stats.Average:N1}"); // Formatted as a Number with 1 decimal
            Console.WriteLine($"The letter grade is {stats.Letter}");
            Console.WriteLine(Book.CATEGORY);
        }

        static void OnGradeAdded(object sender, EventArgs e)   //method to be invoked by Event
        {
            Console.WriteLine("A grade was added");
        }
    }
}
