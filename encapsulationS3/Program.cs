using DbAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace encapsulationS3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Parse("31/01/2019");
            DateTime date2 = DateTime.Now;
            Console.WriteLine(date2 > date1);
            Console.ReadKey();
        }
    }

    
}
