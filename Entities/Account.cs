using System;

namespace Entities
{
    public class Account
    {
        private int id;
        private decimal balance;
        private DateTime created;


        /// <summary>
        /// used for initial account creation
        /// </summary>
        /// <param name="initialBalance"></param>
        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
            id = 0;
            created = DateTime.Now;
        }
        /// <summary>
        /// used when an account is retrieved from the database
        /// </summary>
        /// <param name="created"></param>
        /// <param name="balance"></param>
        /// <param name="id"></param>
        public Account(DateTime created, decimal balance, int id)
        {
            Created = created;
            Balance = balance;
            Id = id;
        }
        /// <summary>
        /// sets or gets created date
        /// </summary>
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
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
        /// gets or sets id
        /// </summary>
        public int Id
        {
            get => id;
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
            }
        }

        /// <summary>
        /// withdraws from the account
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(decimal amount)
        {
            if (amount > 25000 || amount <= 0)
            {
                throw new ArgumentException("invalid amount");
            }
            var (isValid, errorMessage) = ValidateTransfer(0 - amount, balance);
            if (isValid)
            {
                Balance -= amount;
            }
            else
            {
                throw new ArgumentException(errorMessage);
            }
        }
        /// <summary>
        /// deposists into the account
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(decimal amount)
        {
            var (isValid, errorMessage) = ValidateTransfer(amount, balance);
            if (isValid)
            {
                Balance += amount;
            }
            else
            {
                throw new ArgumentException(errorMessage);
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
        /// <summary>
        /// validates transaction
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public static (bool isValid, string errorMessage) ValidateTransfer(decimal amount, decimal balance)
        {

            if (amount + balance < 1000000000 && amount + balance > -1000000000)
            {
                return (true, string.Empty);
            }
            else
            {
                return (false, "exceeds account limits");
            }
        }


    }
}
