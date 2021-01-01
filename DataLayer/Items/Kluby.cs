using System.Collections.Generic;
using DataLayer.Interfaces;

namespace DataLayer.Items
{
    public class Kluby : ITableItem
    {
        public int kID { get; set; }
        public string nazev_klubu { get; set; }
        public int prezident_klubu_prezID { get; set; }
        public virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>
            {
                {"@kID", kID.ToString()},
                {"@nazev_klubu", nazev_klubu},
                {"@prezident_klubu_prezID", prezident_klubu_prezID.ToString()},
            };
        }
    }
}
