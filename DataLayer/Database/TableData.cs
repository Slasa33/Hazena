using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer.Database
{
    public static class TableData
    {
        public static DataTable Querry(string sqlString)
        {
            return Querry(sqlString, null);
        }

        public static DataTable Querry(string sqlString, Dictionary<string, string> arguments)
        {
            DataTable records;
            Databaze.Instance.Connect();
            using (var command = PrepareCommand(sqlString, arguments))
            {
                using (var adapter = new SqlDataAdapter(command))
                using (var ds = new DataSet())
                {

                    adapter.Fill(ds, "SelectQuerry");
                    records = ds.Tables["SelectQuerry"];
                }
            }

            Databaze.Instance.Close();
            return records;
        }

        public static int NonQuerry(string sqlString, Dictionary<string, string> arguments)
        {
            int rowNumber = 0;
            Databaze.Instance.Connect();
            using (var command = PrepareCommand(sqlString, arguments))
            {
                try
                {
                    rowNumber = command.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw exception;

                }
                finally
                {
                    Databaze.Instance.Close();
                }
            }
            return rowNumber;
        }

        private static SqlCommand PrepareCommand(string sqlString, Dictionary<string, string> args)
        {
            var command = new SqlCommand(sqlString, Databaze.Instance.Connection);
            if (args == null) return command;

            foreach (var item in args)
            {
                command.Parameters.AddWithValue(item.Key, (object)item.Value ?? DBNull.Value);
            }

            return command;
        }
    }
}
