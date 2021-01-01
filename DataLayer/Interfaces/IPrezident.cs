using System.Collections.Generic;
using DataLayer.Items;

namespace DataLayer.Interfaces
{
    public interface IPrezident
    {
        PrezidentKlubu SelectHeslo(string rodne_cislo, string heslo);

        IEnumerable<PrezidentKlubu> SelectArray();
    }
}
