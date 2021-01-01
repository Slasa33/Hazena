using System.Data.SqlClient;

namespace DataLayer
{
    public class Databaze
    {

        private static readonly string sqlCon = @"data source = localhost\SQLEXPRESS; initial catalog = VIS; integrated security = SSPI";

        private static Databaze _db;

        public static Databaze Instance
        {
            get
            {
                if (_db == null)
                    _db = new Databaze(sqlCon);

                return _db;
            }
        }

        public SqlConnection Connection { get; }

        private Databaze(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Connect()
        {

            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }

    }
}
