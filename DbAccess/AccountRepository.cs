using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entities;

namespace DbAccess
{
    public class AccountRepository : BaseRepository
    {
        //public Account GetAccount(int id)
        //{
        //    DataTable dt = ExecuteQuery($"select * from Accounts where Id = {id};");
        //    //Returner null hvis querying ikke har nogen rows. 
        //    if (dt.Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    return new Account
        //    (
        //        (DateTime)dt.Rows[0]["Type"],
        //        (decimal)dt.Rows[0]["Balance"],
        //        (int)dt.Rows[0]["Id"]
        //    );
        //}

        //public int DeleteAccount(int id)
        //{
        //    return ExecuteNonQuery($"Delete from Accounts where Id = {id};");
        //}

        //public int NewAccount(Account acc)
        //{
        //    return ExecuteNonQuery($"insert into Accounts (Balance, Created) values ({acc.Balance}, '{acc.Created.ToString("yyyy-MM-dd")}')");
        //}

        //public int UpdateAccount(Account acc)
        //{
        //    return ExecuteNonQuery($"update Accounts set Balance = {acc.Balance}, Created = '{acc.Created.ToString("yyyy-MM-dd")}' where Id = {acc.Id}");
        //}

        //public void InsertBulkAccounts(List<Account> accs)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Id", typeof(int));
        //    dt.Columns.Add("Balance", typeof(decimal));
        //    dt.Columns.Add("Created", typeof(DateTime));

        //    accs.ForEach(ac => dt.Rows.Add(ac.Id, ac.Balance, ac.Created));

        //    ExecuteBulk(dt, "accounts");
        //}

        //public List<Account> GetAllAcounts()
        //{
        //    DataTable dt = ExecuteQuery("select * from Accounts;");
        //    List<Account> accounts = new List<Account>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        accounts.Add(new Account(
        //            (DateTime)row["Created"],
        //            (decimal)row["Balance"],
        //            (int)row["Id"])
        //            );
        //    }
        //    return accounts;
        //}

        //public decimal GetAccountTotals()
        //{
        //    return decimal.Parse(ExecuteQuery("select sum(Balance) from accounts;").Rows[0][0].ToString());
        //}

        
    }
}
