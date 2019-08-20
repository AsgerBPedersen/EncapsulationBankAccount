using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities;

namespace DbAccess
{
    public class TransactionRepository
    {
        private IBaseRepository _baseRepository;

        public TransactionRepository()
        {
            _baseRepository = new BaseRepository();
        }
        public TransactionRepository(IBaseRepository br)
        {
            _baseRepository = br;
        }

        //public Transaction GetTransaction(int id)
        //{
        //    DataTable dt = _baseRepository.ExecuteQuery($"select * from Transactions where Id = {id};");
        //    //Returner null hvis querying ikke har nogen rows. 
        //    if (dt.Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    return new Transaction
        //    (
        //        (decimal)dt.Rows[0]["Amount"],
        //        (int)dt.Rows[0]["AccountId"],
        //        (int)dt.Rows[0]["Id"]
        //    );
        //}

        //public int DeleteTransaction(int id)
        //{
        //    return _baseRepository.ExecuteNonQuery($"Delete from Transactions where Id = {id};");
        //}

        //public int NewTransaction(Transaction ta)
        //{
        //    return _baseRepository.ExecuteNonQuery($"insert into Transactions (AccountId, Amount) values ({ta.AccountId}, {ta.Amount})");
        //}

        //public int UpdateTransaction(Transaction ta)
        //{
        //    return _baseRepository.ExecuteNonQuery($"update Transactions set Account = {ta.AccountId}, Amount = {ta.Amount} where Id = {ta.Id}");
        //}

        //public List<Transaction> GetAllTransactions()
        //{
        //    DataTable dt = _baseRepository.ExecuteQuery("select * from Transactions;");
        //    List<Transaction> transactions = new List<Transaction>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        transactions.Add(new Transaction(
        //            (decimal)row["Amount"],
        //            (int)row["AccountId"],
        //            (int)row["Id"]
        //            )
        //        );
        //    }
        //    return transactions;
        //}
    }
}
