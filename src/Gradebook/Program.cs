using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Harry potter");
            EnterGrade(book);
            var stats = book.GetStatistics();

            Console.WriteLine($"The low grade is {stats.Low}");
            Console.WriteLine($"The high grade is {stats.High}");
            Console.WriteLine($"The result is {stats.Average:N2}");
            Console.WriteLine($"The Grade is {stats.Letter}");
        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or press q to exit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.Addgrade(grade);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //finally
                //{
                //  Console.WriteLine("/**/");
                //}

            }
        }
    }
}
