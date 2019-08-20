using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Transaction : Entity
    {
        protected string sender;
        protected string reciever;
        protected decimal amount;
        protected DateTime timestamp;

        public Transaction(int id,DateTime timestamp, decimal amount, string reciever, string sender) : base(id)
        {
            Timestamp = timestamp;
            Amount = amount;
            Reciever = reciever;
            Sender = sender;
        }

        public Transaction(DateTime timestamp, decimal amount, string reciever, string sender) : this(default, timestamp, amount, reciever, sender)
        {
            
        }

        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Reciever
        {
            get { return reciever; }
            set { reciever = value; }
        }

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        public static bool ValidateTimestamp(DateTime timestamp)
        {
            if (timestamp > DateTime.Now)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public static bool ValidateAmount(decimal amount)
        {
            if (amount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
