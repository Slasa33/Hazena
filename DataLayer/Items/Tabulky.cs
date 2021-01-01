using System.Collections.Generic;
using DataLayer.Abstract;

namespace DataLayer.Items
{
    public class Tabulky : ITableItem
    {
        public int liga_lID { get; set; }
        public int klub_kID { get; set; }
        public int body { get; set; }
        public int vyhry { get; set; }
        public int remizy { get; set; }
        public int prohry { get; set; }
        public int vstrelene_branky { get; set; }
        public int utrzene_branky { get; set; }

        public virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>
            {
                {"@liga_lID", liga_lID.ToString()},
                {"@klub_kID", klub_kID.ToString()},
                {"@body", body.ToString()},
                {"@vyhry", vyhry.ToString()},
                {"@remizy", remizy.ToString()},
                {"@prohry", prohry.ToString()},
                {"@vstrelene_branky", vstrelene_branky.ToString()},
                {"@utrzene_branky", utrzene_branky.ToString()}
            };
        }
    }
}
