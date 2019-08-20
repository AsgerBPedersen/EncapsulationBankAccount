using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Entities
{
    public class Account : Entity
    {
        protected string accountNumber;
        protected decimal balance;
        protected DateTime created;
        protected decimal creditLimit;
        protected List<Transaction> transactions;

        /// <summary>
        /// Initializes account with an id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountNumber"></param>
        /// <param name="balance"></param>
        /// <param name="created"></param>
        /// <param name="creditLimit"></param>
        /// <param name="transactions"></param>
        public Account(int id, string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions) : base(id)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Created = created;
            CreditLimit = creditLimit;
            Transactions = transactions;
        }

        /// <summary>
        /// Initializes account without an id
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="balance"></param>
        /// <param name="created"></param>
        /// <param name="creditLimit"></param>
        /// <param name="transactions"></param>
        public Account(string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions) 
            :this(default, accountNumber, balance, created, creditLimit, transactions)
        {
            
        }

        /// <summary>
        /// gets or sets the accountnumber
        /// </summary>
        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (ValidateAccountNumber(value))
                {
                    accountNumber = value;
                } else
                {
                    throw new ArgumentException("wrong account number format");
                }
            }
        }

        /// <summary>
        /// gets or sets the balance
        /// </summary>
        public decimal Balance
        {
            get { return balance; }
            set {
                if (value > 999999999 || value < -999999999)
                {
                    throw new ArgumentOutOfRangeException("balance exceeds the limits");
                }
                balance = value;
            }
        }

        /// <summary>
        /// sets or gets created date
        /// </summary>
        public DateTime Created
        {
            get { return created; }
            set {
                if (ValidateCreatedDate(value)) {
                    created = value;
                } else {
                    throw new ArgumentException("Date can't be in future");
                }
            }
        }

        /// <summary>
        /// gets or sets creditlimit
        /// </summary>
        public decimal CreditLimit
        {
            get { return creditLimit; }
            set {
                if (ValidateCreditLimit(value))
                {
                    creditLimit = value;
                } else
                {
                    throw new ArgumentException("credit limit can't be less than 0");
                }
            }
        }
        /// <summary>
        /// gets or set transactions
        /// </summary>
        public List<Transaction> Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }


        /// <summary>
        /// withdraws from the account
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Withdraw(decimal amount)
        {
            if ((CreditLimit + Balance - amount) < 0)
            {
                throw new ArgumentException("withdraw exceeds credit limit");
            } else if(amount <= 0)
            {
                throw new ArgumentException("only positive numbers");
            } else
            {
                Balance -= amount;
            }
        }
        /// <summary>
        /// deposists into the account
        /// </summary>
        /// <param name="amount"></param>
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("only positive numbers");
            }
            else
            {
                Balance += amount;
            }
        }

        /// <summary>
        /// gets days since creation
        /// </summary>
        /// <returns></returns>
        public int GetDaysSinceCreation()
        {
            return (DateTime.Now - created).Days;
        }



        public static bool ValidateAccountNumber(string accountNumber)
        {
            if (!Regex.Match(accountNumber, @"^[0-9]{4}\s[0-9]{6,15}$").Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateCreatedDate(DateTime createdDate)
        {
            if (createdDate > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidateCreditLimit(decimal creditLimit)
        {
            if(creditLimit < 0)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
