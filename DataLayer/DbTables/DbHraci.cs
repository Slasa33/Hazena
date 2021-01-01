using System.Collections.Generic;
using System.Data;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DataLayer.DbTables
{
    public class DbHraci : IHraci
    {
        protected string SqlSelect
            => "";

        protected string SqlInsert
            => "INSERT INTO hrac (post_pID, klub_kID, jmeno, prijmeni, rodne_cislo, heslo)" +
               "VALUES (@post_pID, @klub_kID, @jmeno, @prijmeni, @rodne_cislo, @heslo)";

        protected string SqlUpdate
            => "UPDATE hrac SET post_pID = @post_pID, klub_kID = @klub_kID, jmeno = @jmeno, prijmeni = @prijmeni, rodne_cislo = @rodne_cislo, heslo = @heslo " +
               "WHERE hID = @hID";

        protected string SqlDelete
            => "DELETE FROM hrac WHERE hID = @hID";

        private static string SqlSelectHraci
            => "SELECT hID, jmeno, prijmeni FROM klub " +
               "JOIN hrac ON hrac.klub_kID = klub.kID " +
               "WHERE kID = @kID";

        private static string SqlSelectId
            => "SELECT hID, post_pID, klub_kID, jmeno, prijmeni, rodne_cislo, heslo FROM hrac " +
               "WHERE hID = @hID";


        private static string SqlSelectLogin
           => "SELECT hID, jmeno, prijmeni, rodne_cislo, heslo FROM hrac where " + "rodne_cislo = @rodn" +
            "e_cislo AND heslo = @Heslo";

        public Hraci SelectHeslo(string rodne_cislo, string heslo)
        {
            Hraci r = null;
            var args = new Dictionary<string, string>
            {
                { "@rodne_cislo", rodne_cislo },
                { "@Heslo", heslo }
            };

            using (var table = TableData.Querry(SqlSelectLogin, args))
            {
                if (table.Rows.Count != 0)
                {
                    r = new Hraci
                    {
                        hID = (int)table.Rows[0]["rID"],
                        jmeno = (string)table.Rows[0]["jmeno"],
                        prijmeni = (string)table.Rows[0]["prijmeni"],
                    };
                }
            }
            return r;
        }

        public IEnumerable<Hraci> SelectHraci(int id)
        {
            var args = new Dictionary<string, string>
            {
                {"@kID", id.ToString() }
            };

            List<Hraci> hraci = new List<Hraci>();

            using (var table = TableData.Querry(SqlSelectHraci, args))
            {
                foreach(DataRow column in table.Rows)
                {
                    Hraci _hraci = new Hraci
                    {
                        hID = int.Parse(column[0].ToString()),
                        jmeno = column[1].ToString(),
                        prijmeni = column[2].ToString()
                    };

                    hraci.Add(_hraci);

                }
            }
            return hraci;
        }

        public Hraci SelectId(int id)
        {
            Hraci a = null;
            var args = new Dictionary<string, string>
            {
                {"@hID", id.ToString() }
            };
            using (var table = TableData.Querry(SqlSelectId, args))
            {
                if (table.Rows.Count != 0)
                {
                    a = new Hraci
                    {
                        hID = (int)table.Rows[0]["hID"],
                        post_pID = (int)table.Rows[0]["post_pID"],
                        klub_kID = (int)table.Rows[0]["klub_kID"],
                        jmeno = (string)table.Rows[0]["jmeno"],
                        prijmeni = (string)table.Rows[0]["prijmeni"],
                        rodne_cislo = (string)table.Rows[0]["rodne_cislo"],
                        heslo = (string)table.Rows[0]["heslo"]
                    };
                }
            }
            return a;
        }

        public int Insert(ITableItem item)
        {
            return TableData.NonQuerry(SqlInsert, item.GetArgs());
        }

        public int Update(ITableItem item)
        {
            return TableData.NonQuerry(SqlUpdate, item.GetArgs());
        }

        public int Delete(ITableItem item)
        {
            return TableData.NonQuerry(SqlDelete, item.GetArgs());
        }
    }
}
