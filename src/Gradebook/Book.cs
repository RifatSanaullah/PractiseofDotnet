using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class Book
     {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void Addgrade(double grade)
        {
            grades.Add(grade);
        }

        public void getstatistics(){
            var result = 0.0;
            var lowergrade = double.MaxValue;
            var highergrade = double.MinValue;

            foreach(var number in grades){
                lowergrade = Math.Min(number, lowergrade);
                highergrade = Math.Max(number, highergrade);
                result += number;
            }

            result /= grades.Count;
            Console.WriteLine($"The low grade is {lowergrade}");
            Console.WriteLine($"The high grade is {highergrade}");
            Console.WriteLine($"The result is {result:N2}");
        }
        
        private List<double> grades;
        private string name;
    }
    
}