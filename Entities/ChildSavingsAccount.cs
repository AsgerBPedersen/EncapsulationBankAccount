using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Entities
{
    public class ChildSavingsAccount : Account
    {
        private string childSsn;
        private int yearsLocked;

        public ChildSavingsAccount(int id, string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions, string childSsn, int yearsLocked) 
            : base(id, accountNumber, balance, created, creditLimit, transactions)
        {
            ChildSsn = childSsn;
            YearsLocked = yearsLocked;
        }

        public ChildSavingsAccount(string accountNumber, decimal balance, DateTime created, decimal creditLimit, List<Transaction> transactions, string childSsn, int yearsLocked)
            : this(default, accountNumber, balance, created, creditLimit, transactions, childSsn, yearsLocked)
        {
            
        }

        public int Age
        {
            get
            {
                DateTime birthDay = DateTime.Parse($"{ChildSsn.Substring(0, 2)}/{ChildSsn.Substring(2, 2)}/{ChildSsn.Substring(4, 2)}");
                int years = DateTime.Now.Year - birthDay.Year;

                if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
                    years--;

                return years;
            }
        }

        public int YearsLocked
        {
            get { return yearsLocked; }
            set {
                if (Age + value < 14 )
                {
                    throw new ArgumentException("Account must be locked past the childs 14th birthday");
                } else if(value < 7)
                {
                    throw new ArgumentException("Account must be locked for atleast 7 years");
                } else if(Created.AddYears(value).Year > DateTime.Parse($"{ChildSsn.Substring(0, 2)}/{ChildSsn.Substring(2, 2)}/{ChildSsn.Substring(4, 2)}").AddYears(21).Year)
                {
                    throw new ArgumentException("account cant be locked past the year the child turns 21");
                } else
                {
                    yearsLocked = value;
                }
            }
        }


        public string ChildSsn
        {
            get { return childSsn; }
            set {
                if (Regex.Match(value, @"^[0-3][0-9][0-1][1-9]\d{2}-\d{4}?[^0-9]*$").Success)
                {
                    childSsn = value;
                } else
                {
                    throw new ArgumentException("wrong ssn format");
                }
            }
        }

        public DateTime CanBeWithdrawedFrom()
        {
            return Created.AddYears(YearsLocked);
        }

        public override void Withdraw(decimal amount)
        {
            if (DateTime.Now < CanBeWithdrawedFrom())
            {
                throw new Exception("The account is still locked");
            } else if (Balance - amount < 0)
            {
                throw new ArgumentException("you cant withdraw past 0");
            } else
            {
                Balance =- amount;
            }
        }

        public override void Deposit(decimal amount)
        {
            if (transactions.Where(t => t.Timestamp.AddYears(1) > DateTime.Now).Sum(t => t.Amount) + amount > 6000)
            {
                throw new ArgumentException("you can only deposit 6000 within a 1 year period");
            } else if(Balance + amount > 72000)
            {
                throw new ArgumentException("the account balance cannot exceed 72000");
            } else
            {
                Balance =+ amount;
            }
        }

        
    }
}
