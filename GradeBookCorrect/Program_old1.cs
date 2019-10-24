/* using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
//             var x = 34.1;    //Implicit Typing
//            var y = 10.3;
//            var result = x + y;

//            Console.WriteLine(result);

            // double[] numbers = new double[3];
//            var numbers = new double[3];
//            numbers[0] = 12.7;
//            numbers[1] = 10.3;
//            numbers[2] = 6.11;
            var numbers = new[] { 12.7, 10.3, 6.11, 4.1 };  // Constant Sized
            // List<double> grades;    //This list will only store values of type "double"
            // List<double> grades = new List<double>();
            // var grades = new List<double>();    // Same as above but Implicit Typing
            var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };  // Dynamically Sized
            grades.Add(56.1);

            var result = 0.0;
//             var result = numbers[0];
            // result = result + numbers[1];
//            result += numbers[1];
            // result = result + numbers[2];
//            result += numbers[2];

            // foreach(var number in numbers)
            foreach(var number in grades)
            {
                result += number;
            }
            result /= grades.Count;

            //Console.WriteLine($"The average grade is {result}");
            Console.WriteLine($"The average grade is {result:N1}"); // Formatted as a Number with 1 decimal

            if (args.Length > 0) 
            {
                //Console.WriteLine("Hello Mikael!");
                //Console.WriteLine("Hello " + args[0] + "!!");
                Console.WriteLine($"Hello {args[0]}!!!");
            }
            else
            {
                Console.WriteLine("Hello!");
            }
        }
    }
}
    */