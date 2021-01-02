using System;
using System.Collections.Generic;
using System.Data;
using DataLayer.Database;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace DataLayer.DbTables
{
    public class DbZapasy : IZapasy
    {
        protected string SqlSelect
            => "SELECT zID, domaciID, hosteID, rozhodci_rID, domaci_skore, hoste_skore FROM zapasy";

        private static string SqlSelectId
            => "SELECT zID, k1.nazev_klubu AS domaci, k2.nazev_klubu AS hoste, r.jmeno, r.prijmeni, domaci_skore, hoste_skore, datum_cas FROM zapasy " +
            "JOIN klub k1 ON k1.kID = zapasy.domaciID " +
            "JOIN klub k2 ON k2.kID = zapasy.hosteID " +
            "JOIN rozhodci r ON r.rID = zapasy.rozhodci_rID " +
            "WHERE zID = @zID";


        private static string SqlSelectDomaciHraci
            => "SELECT h1.jmeno AS Jméno, h1.prijmeni AS Příjmení, p.nazev_postu AS Post FROM zapasy " +
            "JOIN klub ON kID = zapasy.domaciID " +
            "JOIN hrac h1 ON h1.klub_kID = klub.kID " +
            "JOIN post p ON p.pid = h1.post_pid " +
            "WHERE zID = @zID";

        private static string SqlSelectHosteHraci
            => "SELECT h1.jmeno AS Jméno, h1.prijmeni AS Příjmení, p.nazev_postu AS Post FROM zapasy " +
            "JOIN klub ON kID = zapasy.hosteID " +
            "JOIN hrac h1 ON h1.klub_kID = klub.kID " +
            "JOIN post p ON p.pid = h1.post_pid " +
            "WHERE zID = @zID";

        public Zapasy SelectId(int id)
        {
            Zapasy a = null;
            var args = new Dictionary<string, string>
            {
                {"@zID", id.ToString() }
            };
            using (var table = TableData.Querry(SqlSelectId, args))
            {
                if (table.Rows.Count != 0)
                {
                    a = new Zapasy
                    {
                        zID = (int)table.Rows[0]["zID"],
                        domaci_nazev = (string)table.Rows[0]["domaci"],
                        hoste_nazev = (string)table.Rows[0]["hoste"],
                        jmeno = (string)table.Rows[0]["jmeno"],
                        prijmeni = (string)table.Rows[0]["prijmeni"],
                        domaci_skore = (int)table.Rows[0]["domaci_skore"],
                        hoste_skore = (int)table.Rows[0]["hoste_skore"],
                        datum_cas = DateTime.Parse(table.Rows[0]["datum_cas"].ToString())
                    };
                }
            }
            return a;
        }

        public DataTable SelectPlayersDomaci(int id)
        {

            var args = new Dictionary<string, string>
            {
                {"@zID", id.ToString() }
            };

            return TableData.Querry(SqlSelectDomaciHraci, args);
        }

        public DataTable SelectPlayersHoste(int id)
        {
            var args = new Dictionary<string, string>
            {
                {"@zID", id.ToString() }
            };

            return TableData.Querry(SqlSelectHosteHraci, args);
        }

        public IEnumerable<Zapasy> VyberVsechnyZapasy()
        {
            List<Zapasy> zapasy = new List<Zapasy>();

            using (var table = TableData.Querry(SqlSelect))
            {
                foreach (DataRow column in table.Rows)
                {
                    Zapasy _zapasy = new Zapasy
                    {
                        zID = int.Parse(column[0].ToString()),
                        domaciID = int.Parse(column[1].ToString()),
                        hosteID = int.Parse(column[2].ToString()),
                        rozhodci_rID = int.Parse(column[3].ToString()),
                        domaci_skore = int.Parse(column[4].ToString()),
                        hoste_skore = int.Parse(column[5].ToString())
                    };

                    zapasy.Add(_zapasy);
                }
            }

            return zapasy;
        }
    }
}
