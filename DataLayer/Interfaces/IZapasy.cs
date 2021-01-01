using System.Collections.Generic;
using System.Data;
using DataLayer.Items;

namespace DataLayer.Interfaces
{
    public interface IZapasy
    {
        IEnumerable<Zapasy> VyberVsechnyZapasy();
        Zapasy SelectId(int id);
        DataTable SelectPlayersDomaci(int id);
        DataTable SelectPlayersHoste(int id);
    }
}
