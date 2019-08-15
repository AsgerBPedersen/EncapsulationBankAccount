using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Transaction
    {
        private int id;
        private int accountId;
        private decimal amount;

        public Transaction(decimal amount, int accountId)
        {
            Amount = amount;
            AccountId = accountId;
        }

        public Transaction(decimal amount, int accountId, int id)
        {
            Amount = amount;
            AccountId = accountId;
            Id = id;
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
