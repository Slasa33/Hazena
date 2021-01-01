using System.Collections.Generic;
using System.Data;
using DataLayer.Abstract;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DataLayer.DbTables
{
    public class DbKluby : IKluby
    {
        private string SqlSelect
            => "SELECT kID, nazev_klubu, prezident_klubu_prezID FROM klub";

        protected string SqlInsert
            => "INSERT INTO klub(prezident_klubu_prezID, nazev_klubu) VALUES(@prezident_klubu_prezID, @nazev_klubu)";

        protected string SqlUpdate
            => "UPDATE klub SET nazev_klubu = @nazev_klubu, prezident_klubu_prezID = @prezident_klubu_prezID WHERE kID = @kID";

        protected string SqlDelete
            => "";

        private static string SqlSelectId
            => "SELECT kID, nazev_klubu, prezident_klubu_prezID FROM klub WHERE kID = @kID";


        public IEnumerable<Kluby> VyberVsechnyKluby()
        {
            List<Kluby> kluby = new List<Kluby>();

            using (var table = TableData.Querry(SqlSelect))
            {
                foreach(DataRow column in table.Rows)
                {
                    Kluby _kluby = new Kluby
                    {
                        kID = int.Parse(column[0].ToString()),
                        nazev_klubu = column[1].ToString(),
                        prezident_klubu_prezID = int.Parse(column[2].ToString())
                    };

                    kluby.Add(_kluby);
                }
            }

            return kluby;
        }

        public Kluby SelectId(int id)
        {
            Kluby a = null;
            var args = new Dictionary<string, string>
            {
                {"@kID", id.ToString() }
            };
            using (var table = TableData.Querry(SqlSelectId, args))
            {
                if (table.Rows.Count != 0)
                {
                    a = new Kluby
                    {
                        kID = (int)table.Rows[0]["kID"],
                        nazev_klubu = (string)table.Rows[0]["nazev_klubu"],
                        prezident_klubu_prezID = (int)table.Rows[0]["prezident_klubu_prezID"]
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



    }
}
