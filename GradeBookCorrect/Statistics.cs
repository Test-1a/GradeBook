﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public double High;
        public double Low;

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:  // C# ver 7
                        return 'A';
                        
                    case var d when d >= 80.0:
                        return 'B';
                        
                    case var d when d >= 70.0:
                        return 'C';
                        
                    case var d when d >= 60.0:
                        return 'D';
                       
                    default:
                        return 'F';
                }
            }
        }
       


        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }

        public Statistics()     //Constructor
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}
