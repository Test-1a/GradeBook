using System;
using System.Collections.Generic;   //List
using System.Text;
using System.IO;    //File

namespace GradeBook
{
    //This is a new special comment

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public interface IBook  //interface class
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook  //abstract class //General class
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded; 
        public abstract void AddGrade(double grade);     //abstract method => also virtual
        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book   //don't have to inherit from Base class, it is OK
    {                               //to only inherit from the Interface (IBook)
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (StreamWriter writer = File.AppendText($"{Name}.txt"))    //impl IDisposible
            {                                   //used with Files or Sockets
                writer.WriteLine(grade);

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }   //here the fileHandle(SW) is released IMMEDIATELY by the GC
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (StreamReader reader = File.OpenText($"{Name}.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    double number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

                return result;
        }
    }

    public class InMemoryBook : Book
    //public class InMemoryBook : Book, IBook //can inherit both classes and interfaces(0 or more)
    //public class Book
    {
        public InMemoryBook(string name) : base(name)   //When I'm creating a InMemoryBook I'm also creating a Book
        {                                               //so I must run the constructor of the Book too
            grades = new List<double>();
           // Name = name;
        }

        //public void AddLetterGrade(char letter)
        public void AddGrade(char letter)
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

        public override event GradeAddedDelegate GradeAdded;    //override the event in Base class

        public override void AddGrade(double grade) //to override the AddGrade method in BookBase
        {
            if (grade <= 100 && grade >= 0)   // grade is 0 - 100
            {
                grades.Add(grade);  // Storing the grade

                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());  //raising an Event when a
                }                                       //grade has been added
            }
            else
            {
                //Console.WriteLine("Invalid Value!");

                //Throwing an exception due to the wrong value of a parameter
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public override Statistics GetStatistics()  //override method in Base class
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
             }

            return result;
        }

        private List<double> grades;    // This is a Field

 /*     //public string Name;
        private string name;    //make it private to control access to this state
        public string Name  //Not a method, it does not have parenthesis
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }       */

        //Commented out due to will be inheriting it from NamedObject
        //public string Name
        //{
        //    get; set;
        //}

        //readonly string category;
        public const string CATEGORY = "Science";
    }
}

