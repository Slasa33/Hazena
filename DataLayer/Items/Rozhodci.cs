using System.Collections.Generic;
using DataLayer.Interfaces;

namespace DataLayer.Items
{
    public class Rozhodci : ITableItem
    {
        public int rID { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string rodne_cislo { get; set; }
        public string telefon { get; set; }
        public string heslo { get; set; }
        public virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>
            {
                {"@rID", rID.ToString()},
                {"@jmeno", jmeno},
                {"@prijmeni", prijmeni},
                {"@rodne_cislo", rodne_cislo},
                {"@telefon", telefon},
                {"@heslo", heslo}
            };
        }

        public override string ToString()
        {
            return $"{rID} - {jmeno} - {prijmeni}  - {rodne_cislo}  - {telefon}";
        }
    }
}
