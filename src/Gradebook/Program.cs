using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("");
            book.Addgrade(32.1);
            book.Addgrade(22.4);
            book.Addgrade(34.2);
            book.getstatistics();
        }
    }
}
