using System.Collections.Generic;
using System.Data;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DataLayer.DbTables
{
    public class DbRozhodci : IRozhodci
    {
        protected string SqlSelect
            => "SELECT rID, jmeno, prijmeni, rodne_cislo, telefon FROM rozhodci";

        protected string SqlInsert
            => "INSERT INTO rozhodci (jmeno, prijmeni, rodne_cislo, telefon, heslo) VALUES (@jmeno, @prijmeni, @rodne_cislo, @telefon, @heslo)";

        protected string SqlUpdate
            => "UPDATE rozhodci SET jmeno = @jmeno, prijmeni = @prijmeni, rodne_cislo = @rodne_cislo, telefon = @telefon WHERE rID = @rID";

        protected string SqlDelete
            => "DELETE FROM rozhodci WHERE rID = @rID";

        private static string SqlSelectLogin
            => "SELECT rID, jmeno, prijmeni, rodne_cislo, telefon, heslo FROM rozhodci where " + "rodne_cislo = @rodne_cislo AND heslo = @Heslo";


        public Rozhodci SelectHeslo(string rodne_cislo, string heslo)
        {
            Rozhodci r = null;
            var args = new Dictionary<string, string>
            {
                { "@rodne_cislo", rodne_cislo },
                { "@Heslo", heslo }
            };

            using (var table = TableData.Querry(SqlSelectLogin, args))
            {
                if (table.Rows.Count != 0)
                {
                    r = new Rozhodci
                    {
                        rID = (int)table.Rows[0]["rID"],
                        jmeno = (string)table.Rows[0]["jmeno"],
                        prijmeni = (string)table.Rows[0]["prijmeni"],
                        telefon = (string)table.Rows[0]["telefon"]
                    };
                }
            }
            return r;
        }

        public IEnumerable<Rozhodci> SelectArray()
        {
            List<Rozhodci> rozhodci = new List<Rozhodci>();

            using (var table = TableData.Querry(SqlSelect))
            {
                foreach (DataRow tablerow in table.Rows)
                {
                    Rozhodci roz = new Rozhodci();

                    roz.rID = int.Parse(tablerow[0].ToString());
                    roz.jmeno = tablerow[1].ToString();
                    roz.prijmeni = tablerow[2].ToString();
                    roz.rodne_cislo = tablerow[3].ToString();
                    roz.telefon = tablerow[4].ToString();

                    rozhodci.Add(roz);
                }
            }
            return rozhodci;
        }

        public int Insert(ITableItem item)
        {
            return TableData.NonQuerry(SqlInsert, item.GetArgs());
        }

    }
}
