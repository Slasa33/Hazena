using System;
using System.Collections.Generic;
using DataLayer.Interfaces;

namespace DataLayer.Items
{
    public class Zapasy : ITableItem
    {
        public int zID { get; set; }
        public int domaciID { get; set; }
        public int hosteID { get; set; }
        public int rozhodci_rID { get; set; }
        public int domaci_skore { get; set; }
        public int hoste_skore { get; set; }
        public DateTime datum_cas { get; set; }

        public string domaci_nazev { get; set; }
        public string hoste_nazev { get; set; }

        public string jmeno { get; set; }
        public string prijmeni { get; set; }

        public virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>
            {
                {"@zID", zID.ToString()},
                {"@domaciID", domaciID.ToString()},
                {"@hosteID", hosteID.ToString()},
                {"@rozhodci_rID", rozhodci_rID.ToString()},
                {"@domaci_skore", domaci_skore.ToString()},
                {"@hoste_skore", hoste_skore.ToString()},
                {"@datum_cas", datum_cas.ToString()},
                {"@domaci_nazev", domaci_nazev},
                {"@hoste_nazev", hoste_nazev},
                {"@jmeno", jmeno},
                {"@prijmeni", prijmeni},
            };
        }
    }
}
