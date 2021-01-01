using System.Collections.Generic;
using DataLayer.Items;

namespace DataLayer.Interfaces
{
    public interface ITabulky
    {
        IEnumerable<Tabulky> VyberVsechny();
    }
}
