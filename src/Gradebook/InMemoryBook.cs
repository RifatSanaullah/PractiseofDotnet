using System;
using System.Collections.Generic;
using System.IO;
using static Gradebook.InMemoryBook;

namespace Gradebook
{
    public class Nameobject
    {
        public Nameobject(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }

    public abstract class Book : Nameobject, IBook
    {
        protected Book(string name) : base(name)
        {

        }

        public string name => throw new NotImplementedException();

        public abstract void Addgrade(double grade);

        public abstract statistics GetStatistics();
    }


    public interface IBook
    {
        void Addgrade(double grade);
        statistics GetStatistics();
        string name { get; }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void Addgrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
        }

        public override statistics GetStatistics()
        {
            var result = new statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void checkgrade(string letter)
        {
            switch (letter)
            {
                case "A+":
                    Addgrade(90);
                    break;
                case "A":
                    Addgrade(80);
                    break;
                case "B":
                    Addgrade(70);
                    break;
                case "C":
                    Addgrade(60);
                    break;

                default:
                    Addgrade(0);
                    break;
            }
        }


        public override void Addgrade(double grade)
        {
            grades.Add(grade);
            if (grade <= 100 & grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public override statistics GetStatistics()
        {
            var result = new statistics();

            for (var index = 0; index < grades.Count; index++)
            {
                result.Add(grades[index]);

            }

            return result;
        }

    private List<double> grades;
    }
    
}