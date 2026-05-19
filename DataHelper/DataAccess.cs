using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class DataAccess
    {
        static string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=masterDataFileBIT22;Integrated Security=True;";

        //DataTable
        public DataTable GetCourseCounts()
        {
            return ExecuteStoredProcedure("CountCourse");
        }

        public DataTable GetCountPassedFailed()
        {
            return ExecuteStoredProcedure("CountPassedFailed");
        }

        public DataTable DisplayAverage()
        {
            return ExecuteStoredProcedure("DisplayAverageByCourse");
        }

        public DataTable ExecuteStoredProcedure(string spName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(spName, conn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            return dt;
        }

    }
}
