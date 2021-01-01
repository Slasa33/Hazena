using System.Collections.Generic;
using DataLayer.Abstract;

namespace DataLayer.Items
{
    public class Hraci : ITableItem
    {
        public int hID { get; set; }
        public int post_pID { get; set; }
        public int klub_kID { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string rodne_cislo { get; set; }
        public string heslo { get; set; }
        public virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>
            {
                {"@hID", hID.ToString()},
                {"@post_pID", post_pID.ToString()},
                {"@klub_kID", klub_kID.ToString()},
                {"@jmeno", jmeno},
                {"@prijmeni", prijmeni},
                {"@rodne_cislo", rodne_cislo},
                {"@heslo", heslo}
            };
        }
    }
}
