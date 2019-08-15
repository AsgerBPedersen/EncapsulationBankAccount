using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class AccountTest
    {
        

        [DataTestMethod]
        [DataRow(-1000000001)]
        [DataRow(1000000001)]
        public void AccountInitializationInvalid(int value)
        {
            Exception expected = null;
            try
            {
                Account acc = new Account(value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);    
        }

        [DataTestMethod]
        [DataRow(-999999999)]
        [DataRow(999999999)]
        [DataRow(0)]
        [DataRow(1234)]
        public void AccountInitializationValid(int value)
        {
            Exception expected = null;
            try
            {
                Account acc = new Account(value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNull(expected);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-1234)]
        public void AccountInitializationInvalidId(int value)
        {
            
            Exception expected = null;
            try
            {
                Account acc = new Account(DateTime.Now,123,value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(1234)]
        public void AccountInitializationValidId(int value)
        {

            Exception expected = null;
            try
            {
                Account acc = new Account(DateTime.Now, 123, value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNull(expected);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(-24000)]
        [DataRow(0)]
        public void AccountInvalidWithdraw(int value)
        {
            Account acc = new Account(DateTime.Now, 1000000, 1);

            Exception expected = null;
            try
            {
                acc.Withdraw(value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(24999)]
        [DataRow(1234)]
        public void AccountValidWithdraw(int value)
        {
            Account acc = new Account(DateTime.Now, 1000000, 1);

            Exception expected = null;
            try
            {
                acc.Withdraw(value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNull(expected);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(24000)]
        public void AccountWithdrawExceedingLimits(int value)
        {
            Account acc = new Account(DateTime.Now, -999999999, 1);

            Exception expected = null;
            try
            {
                acc.Withdraw(value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(24000)]
        public void AccountDepositExceedingLimits(int value)
        {
            Account acc = new Account(DateTime.Now, 999999999, 1);

            Exception expected = null;
            try
            {
                acc.Deposit(value);
            }
            catch (Exception ex)
            {
                expected = ex;
            }
            Assert.IsNotNull(expected);
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(-2, 2)]
        [DataRow(-6, 6)]
        public void AccountDaysSinceCreation(int created, int expected)
        {
            Account acc = new Account(DateTime.Now.AddDays(created), 999999999, 1);
            Assert.AreEqual(expected, acc.GetDaysSinceCreation());
        }
    }
}
