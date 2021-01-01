using System.Collections.Generic;
using DataLayer.Abstract;

namespace DataLayer.Items
{
    public class Post : ITableItem
    {
        public int pID { get; set; }
        public string nazev_postu { get; set; }
        public virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>
            {
                {"@pID", pID.ToString()},
                {"@nazev_postu", nazev_postu},
            };
        }
    }
}
