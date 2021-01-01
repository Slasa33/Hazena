using System.Collections.Generic;
using System.Data;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DataLayer.DbTables
{
    public class DbTabulky : ITabulky
    {
        private string SqlSelectVsechny
            => "SELECT liga_lID, klub_kID, body, vyhry, remizy, prohry, vstrelene_branky, utrzene_branky FROM tabulky";

        public IEnumerable<Tabulky> VyberVsechny()
        {
            var _tabulky = new List<Tabulky>();

            using (var table = TableData.Querry(SqlSelectVsechny))
            {
                foreach(DataRow column in table.Rows)
                {
                    var _tabulkyItem = ParseTabulky(column);
                    _tabulky.Add(_tabulkyItem);
                }
            }

            return _tabulky;
        }

        private Tabulky ParseTabulky(DataRow column)
        {
            Tabulky tabulky = new Tabulky
            {
                liga_lID = int.Parse(column["liga_lID"].ToString()),
                klub_kID = int.Parse(column["klub_kID"].ToString()),
                body = int.Parse(column["body"].ToString()),
                vyhry = int.Parse(column["vyhry"].ToString()),
                remizy = int.Parse(column["remizy"].ToString()),
                prohry = int.Parse(column["prohry"].ToString()),
                vstrelene_branky = int.Parse(column["vstrelene_branky"].ToString()),
                utrzene_branky = int.Parse(column["utrzene_branky"].ToString())
            };

            return tabulky;
        }

    }
}
