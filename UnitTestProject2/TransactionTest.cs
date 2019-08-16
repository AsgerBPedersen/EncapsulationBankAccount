using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;
using Autofac.Extras.Moq;
using DbAccess;
using System.Data;

namespace UnitTestProject2
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        public void GetTransaction()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var (dt, tr) = GetRandomTransaction();

                mock.Mock<IBaseRepository>()
                    .Setup(x => x.ExecuteQuery($"select * from Transactions where Id = {tr.Id};"))
                    .Returns(dt);

                var cls = mock.Create<TransactionRepository>();

                Assert.IsTrue(cls.GetTransaction(tr.Id).Id == tr.Id);
            }
        }

        public (DataTable dt, Transaction tr) GetRandomTransaction()
        {
            Transaction tr = new Transaction(123, 23, 2);
            DataTable dt = new DataTable();
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("AccountId", typeof(int));
            dt.Columns.Add("Id", typeof(int));
            dt.Rows.Add(tr.Amount, tr.AccountId, tr.Id);

            return (dt, tr);
        }
    }
}
