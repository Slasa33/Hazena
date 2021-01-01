using System.Collections.Generic;
using DataLayer.Abstract;
using DataLayer.Items;

namespace DataLayer.Interfaces
{
    public interface IHraci
    {
        Hraci SelectHeslo(string rodne_cislo, string heslo);
        Hraci SelectId(int id);
        IEnumerable<Hraci> SelectHraci(int id);

        int Insert(ITableItem item);
        int Update(ITableItem item);
        int Delete(ITableItem item);
    }
}
