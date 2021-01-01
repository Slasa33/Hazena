using System.Collections.Generic;
using DataLayer.Items;

namespace DataLayer.Interfaces
{
    public interface IKluby
    {
        IEnumerable<Kluby> VyberVsechnyKluby();
        Kluby SelectId(int id);

        int Insert(ITableItem item);
        int Update(ITableItem item);
    }
}
