using DbAccess;
using Entities;
using System;
using System.Collections.Generic;

namespace encapsulationS3
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionRepository tr = new TransactionRepository();
            List<Transaction> tas = tr.GetAllTransactions();

            Console.ReadKey();
        }
    }

    
}
