using System.Collections.Generic;
using DataLayer.Abstract;

namespace DataLayer.Items
{
    public class PrezidentKlubu : ITableItem
    {
        public int prezID { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string rodne_cislo { get; set; }
        public string heslo { get; set; }
        public virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>
            {
                {"@prezID", prezID.ToString()},
                {"@jmeno", jmeno},
                {"@prijmeni", prijmeni},
                {"@rodne_cislo", rodne_cislo},
                {"@heslo", heslo}
            };
        }
        public override string ToString()
        {
            return $"{prezID} - {jmeno} - {prijmeni}  - {rodne_cislo}";
        }
    }
}
