using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Customer : Person
    {
        private List<Account> accounts;

        /// <summary>
        /// initializes customer with id
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="id"></param>
        public Customer(int id, string ssn, string lastname, string firstname, List<Account> accounts) : base(id ,ssn, lastname, firstname)
        {
            Accounts = accounts;
        }
        /// <summary>
        /// initializes customer without id
        /// </summary>
        /// <param name="accounts"></param>
        public Customer(string firstname, string lastname, string ssn, List<Account> accounts) : this(default, ssn, lastname, firstname, accounts)
        {
  
        }
        /// <summary>
        /// sets or gets accounts
        /// </summary>
        public List<Account> Accounts
        {
            get { return accounts; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    accounts = value;
                }
            }
        }
        public decimal AccountFee
        {
            get => Prices.Accounts(Rating, Accounts.Count);
        }

        public int MonthlyFreeTransactions
        {
            get => Prices.Transaction(Rating).freeTransactions;
        }

        public decimal TransactionFee
        {
            get => Prices.Transaction(Rating).price;
        }
        /// <summary>
        /// returns the rating which is dependent on the customers total debts and assets
        /// </summary>
        public int Rating
        {

            get
            {
                decimal debts = GetDebts();
                decimal assets = GetAssets();
                if (debts < -2500000)
                {
                    if (assets > 1250000)
                    {
                        return 1;
                    }
                    else if (assets >= 50000)
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (debts <= -250000 && assets >= 50000 && assets <= 1250000)
                {
                    return 3;
                }
                else if (debts < 0 && debts > -250000 && assets > 0 && assets < 50000)
                {
                    if (assets + debts >= 0)
                    {
                        return 4;
                    }
                    else
                    {
                        return 5;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// returns the total debts of the customers accounts
        /// </summary>
        /// <returns></returns>
        public decimal GetDebts()
        {
            if (accounts.Count == 0)
            {
                return 0;
            }
            else
            {
                return Accounts.Where(ac => ac.Balance <= 0).Sum(ac => ac.Balance);
            }
        }
        /// <summary>
        /// returns the total assests of the customers accounts
        /// </summary>
        /// <returns></returns>
        public decimal GetAssets()
        {
            if (accounts.Count == 0)
            {
                return 0;
            }
            else
            {
                return Accounts.Where(ac => ac.Balance >= 0).Sum(ac => ac.Balance);
            }
        }
        /// <summary>
        /// returns the total balance of all the customers accounts
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalBalance()
        {
            if (accounts.Count == 0)
            {
                return 0;
            }
            else
            {
                return GetAssets() + GetDebts();
            }
        }

        public decimal GetTotalFeesFor(DateTime year)
        {
            decimal totalFees = 0;

            List<Transaction> transactions = new List<Transaction>();

            Accounts.ForEach(a => transactions.Concat(a.Transactions.Where(t => t.Timestamp.Year == year.Year)));

            for (int i = 0; i < 12; i++)
            {
                List<Transaction> monthlyTransactions = transactions.Where(t => t.Timestamp.Month == year.AddMonths(0).Month).ToList();
                if (monthlyTransactions.Count > MonthlyFreeTransactions)
                {
                    totalFees += (monthlyTransactions.Count - MonthlyFreeTransactions) * TransactionFee;
                }
            }

            totalFees += (Accounts.Count * AccountFee) * 12;

            return totalFees;
        }

        public decimal GetTotalFeesFor(DateTime from, DateTime to)
        {
            decimal totalFees = 0;

            List<Transaction> transactions = new List<Transaction>();

            int months = ((to.Year - from.Year) * 12) + to.Month - from.Month;

            Accounts.ForEach(a => transactions.Concat(a.Transactions.Where(t => t.Timestamp > from && t.Timestamp < to)));

            for (int i = 0; i < months + 1; i++)
            {
                List<Transaction> monthlyTransactions = transactions.Where(t => t.Timestamp.Month == from.AddMonths(0).Month).ToList();
                if (monthlyTransactions.Count > MonthlyFreeTransactions)
                {
                    totalFees += (monthlyTransactions.Count - MonthlyFreeTransactions) * TransactionFee;
                }
            }

            totalFees += (Accounts.Count * AccountFee) * months;

            return totalFees;
        }


    }
}
