using System.Collections.Generic;
using System.Data;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DataLayer.DbTables
{
    public class DbPrezident : IPrezident
    {
        protected string SqlSelect
            => "SELECT prezID, jmeno, prijmeni, rodne_cislo FROM prezident_klubu";

        protected string SqlInsert

            => "";

        protected string SqlUpdate
            => "";

        protected string SqlDelete
            => "";

        private static string SqlSelectLogin
           => "SELECT prezID, jmeno, prijmeni, rodne_cislo, heslo FROM prezident_klubu where " + "rodne_cislo = @rodne_cislo AND heslo = @Heslo";

        public PrezidentKlubu SelectHeslo(string rodne_cislo, string heslo)
        {
            PrezidentKlubu r = null;
            var args = new Dictionary<string, string>
            {
                { "@rodne_cislo", rodne_cislo },
                { "@Heslo", heslo }
            };

            using (var table = TableData.Querry(SqlSelectLogin, args))
            {
                if (table.Rows.Count != 0)
                {
                    r = new PrezidentKlubu
                    {
                        prezID = (int)table.Rows[0]["prezID"],
                        jmeno = (string)table.Rows[0]["jmeno"],
                        prijmeni = (string)table.Rows[0]["prijmeni"],
                    };
                }
            }
            return r;
        }
        public IEnumerable<PrezidentKlubu> SelectArray()
        {
            List<PrezidentKlubu> prezidenti = new List<PrezidentKlubu>();

            using (var table = TableData.Querry(SqlSelect))
            {
                foreach (DataRow tablerow in table.Rows)
                {
                    PrezidentKlubu prez = new PrezidentKlubu();

                    prez.prezID = int.Parse(tablerow[0].ToString());
                    prez.jmeno = tablerow[1].ToString();
                    prez.prijmeni = tablerow[2].ToString();
                    prez.rodne_cislo = tablerow[3].ToString();

                    prezidenti.Add(prez);
                }
            }
            return prezidenti;
        }
    }
}
