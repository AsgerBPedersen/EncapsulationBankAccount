using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class AccountTest
    {


        [DataTestMethod]
        [DataRow("123")]
        [DataRow("asd")]
        public void AccountInitializationInvalidAccNumber(string value)
        {
            Exception expected = null;
            try
            {
                Account acc = new Account($"{value}", 123, DateTime.Now, 213231, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow("1234 123455")]
        [DataRow("1234 123451234567890")]
        public void AccountInitializationValidAccNumber(string value)
        {
            Exception expected = null;
            try
            {
                Account acc = new Account($"{value}", 123, DateTime.Now, 213231, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNull(expected);
        }

        [DataTestMethod]
        [DataRow(1999999999)]
        [DataRow(-1000000001)]
        public void AccountInitializationInvalidBalance(int value)
        {
            Exception expected = null;
            try
            {
                Account acc = new Account("1234 123455", value, DateTime.Now, 213231, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [TestMethod]
        public void AccountInitializationInvalidDate()
        {
            Exception expected = null;
            try
            {
                Account acc = new Account("1234 123455", 1234, DateTime.Now.AddDays(1), 213231, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-1000000001)]
        public void AccountInitializationInvalidCreditLiimit(int value)
        {
            Exception expected = null;
            try
            {
                Account acc = new Account("1234 123455", 123, DateTime.Now, value, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(100, 100, 201)]
        [DataRow(100, 100, 0)]
        [DataRow(1000000, 250000, 2000000)]
        public void AccountInvalidWithdraw(int balance, int creditlimit, int withdraw)
        {
            Account acc = new Account("1234 123455", balance, DateTime.Now, creditlimit, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });

            Exception expected = null;
            try
            {
                acc.Withdraw(withdraw);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void AccountInvalidDeposit(int deposit)
        {
            Account acc = new Account("1234 123455", 100, DateTime.Now, 100, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });

            Exception expected = null;
            try
            {
                acc.Deposit(deposit);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(1000000, 250000)]
        public void AccountWithdraw(int balance, int withdraw)
        {
            Account acc = new Account("1234 123455", balance, DateTime.Now, 20000000, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });

            acc.Withdraw(withdraw);

            Assert.IsTrue(acc.Balance == balance - withdraw);
        }

        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(1000000, 250000)]
        public void AccountDeposit(int balance, int deposit)
        {
            Account acc = new Account("1234 123455", balance, DateTime.Now, 20000000, new List<Transaction>() { new Transaction(DateTime.Now, 123, "asdasd", "asdasd") });

            acc.Deposit(deposit);

            Assert.IsTrue(acc.Balance == balance + deposit);
        }
    }
}
