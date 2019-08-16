using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbAccess
{
    public interface IBaseRepository
    {

        DataTable ExecuteQuery(string q);

        int ExecuteNonQuery(string q);

        int ExecuteNonQueryScalar(string q);
        
        

    }

}

