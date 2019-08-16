using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DbAccess
{
    public class BaseRepository : IBaseRepository
    {
        protected string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AccountDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DataTable ExecuteQuery(string q)
        {
            DataTable ds = new DataTable();

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(q, con))
            using (SqlDataAdapter dap = new SqlDataAdapter(command))
            {
                dap.Fill(ds);
            }

            return ds;
        }

        public int ExecuteNonQuery(string q)
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(q, con))
            {
                con.Open();

                rowsAffected = com.ExecuteNonQuery();
            }


            return rowsAffected;
        }

        public int ExecuteNonQueryScalar(string q)
        {
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(q, con))
            {
                con.Open();

                return (int)com.ExecuteScalar();
            }

        }

        protected void ExecuteBulk(DataTable dt, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(connection))
                {
                    connection.Open();
                    bulk.DestinationTableName = tableName;
                    bulk.BulkCopyTimeout = 20;
                    bulk.WriteToServer(dt);
                   
                }
                
            }
        }

        
    }
}
