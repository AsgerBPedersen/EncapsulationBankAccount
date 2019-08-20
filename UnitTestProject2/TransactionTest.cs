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
        //[TestMethod]
        //public void GetTransaction()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        var (dt, tr) = GetRandomTransaction();

        //        mock.Mock<IBaseRepository>()
        //            .Setup(x => x.ExecuteQuery($"select * from Transactions where Id = {tr.Id};"))
        //            .Returns(dt);

        //        var cls = mock.Create<TransactionRepository>();

        //        Assert.IsTrue(cls.GetTransaction(tr.Id).Id == tr.Id);
        //    }
        //}

        //public (DataTable dt, Transaction tr) GetRandomTransaction()
        //{
        //    Random rnd = new Random();
        //    Transaction tr = new Transaction(rnd.Next(10000), rnd.Next(1000), rnd.Next(1000));
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Amount", typeof(decimal));
        //    dt.Columns.Add("AccountId", typeof(int));
        //    dt.Columns.Add("Id", typeof(int));
        //    dt.Rows.Add(tr.Amount, tr.AccountId, tr.Id);

        //    return (dt, tr);
        //}
    }
}
