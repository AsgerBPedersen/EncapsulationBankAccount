using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;
using Autofac.Extras.Moq;
using DbAccess;
using System.Data;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class ChildSavingsAccountTest
    {

        [DataTestMethod]
        [DataRow("010405-99951")]
        [DataRow("2020108-9995")]
        public void ChindAccountInitializationInvalidSsn(string value)
        {
            ChildSavingsAccount acc = null;
            Assert.ThrowsException<ArgumentException>(() => acc = new ChildSavingsAccount("1234 123455", 1234, DateTime.Now, 213231, new List<Transaction>(), value, 7));
        }

        [DataTestMethod]
        [DataRow("010405-9995")]
        [DataRow("020108-9995")]
        public void ChindAccountInitializationValidSsn(string value)
        {
                ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 1234, DateTime.Now, 213231, new List<Transaction>(), value, 7);
        }


        [DataTestMethod]
        [DataRow("010405-9995", 10)]
        [DataRow("020108-9995", 14)]
        public void ChindAccountInitializationInvalidYearsLocked(string value, int years)
        {
            ChildSavingsAccount acc = null;
            Assert.ThrowsException<ArgumentException>(() => acc = new ChildSavingsAccount("1234 123455", 1234, DateTime.Now, 213231, new List<Transaction>(), value, years));
        }

        [DataTestMethod]
        [DataRow("010405-9995", 7)]
        [DataRow("020108-9995", 7)]
        public void ChindAccountInitializationValidYearsLocked(string value, int years)
        {
            ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 1234, DateTime.Now, 213231, new List<Transaction>(), value, years);

        }

        [DataTestMethod]
        [DataRow("010405-9995", 7)]
        [DataRow("020108-9995", 7)]
        public void ChindAccountCanBeWithdrawnFrom(string value, int years)
        {
            ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 1234, DateTime.Now, 213231, new List<Transaction>(), value, years);
            Assert.IsTrue(acc.CanBeWithdrawedFrom().Date == DateTime.Now.AddYears(years).Date);

        }

        [DataTestMethod]
        [DataRow("010400-9995", 10)]
        [DataRow("020100-9995", 7)]
        public void ChindAccountWithdraw(string value, int years)
        {
            ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 1234, DateTime.Now.AddYears(-10), 213231, new List<Transaction>(), value, years);
            acc.Withdraw(10);

        }

        [DataTestMethod]
        [DataRow("010400-9995", 10, 200)]
        [DataRow("020100-9995", 10, 300)]
        public void ChindAccountInvalidWithdraw(string value, int years, int withdraw)
        {
            ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 100, DateTime.Now.AddYears(-10), 213231, new List<Transaction>(), value, years);
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdraw));
        }

        [DataTestMethod]
        [DataRow("010404-9995", 12)]
        [DataRow("020104-9995", 14)]
        public void ChindAccountInvalidWithdrawLocked(string value, int years)
        {
            ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 100, DateTime.Now.AddYears(-10), 213231, new List<Transaction>(), value, years);
            Assert.ThrowsException<Exception>(() => acc.Withdraw(10));
        }

        [DataTestMethod]
        [DataRow(101)]
        [DataRow(300)]
        public void ChindAccountInvalidDeposit(int deposit)
        {
            ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 100, DateTime.Now.AddYears(-10), 213231, new List<Transaction>() { new Transaction(DateTime.Now.AddDays(-1), 5900, "asd", "asd") }, "010400-9995", 7);
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(deposit));
        }

        [DataTestMethod]
        [DataRow(1101)]
        [DataRow(1300)]
        public void ChindAccountInvalidDepositExceedAccountLimit(int deposit)
        {
            ChildSavingsAccount acc = new ChildSavingsAccount("1234 123455", 71000, DateTime.Now.AddYears(-10), 0, new List<Transaction>(), "010400-9995", 7);
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(deposit));
        }
    }
}
