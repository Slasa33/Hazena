using System.Collections.Generic;
using DataLayer.Items;

namespace DataLayer.Interfaces
{
    public interface IRozhodci
    {
        IEnumerable<Rozhodci> SelectArray();
        Rozhodci SelectHeslo(string rodne_cislo, string heslo);
    }
}
