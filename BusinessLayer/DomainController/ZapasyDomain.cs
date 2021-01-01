using System.Collections.Generic;
using System.Data;
using System.Linq;
using BusinessLayer.Modely;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class ZapasyDomain
    {
        public IEnumerable<ModelZapasy> SelectVsechnyZapasy(IZapasy _zapasy)
        {
            IEnumerable<Zapasy> zapasy = _zapasy.VyberVsechnyZapasy();
            IEnumerable<ModelZapasy> temp;

            temp = zapasy.Select(o => new ModelZapasy()
            {
                zID = o.zID, domaciID = o.domaciID, hosteID = o.hosteID, rozhodci_rID = o.rozhodci_rID,
                domaci_skore = o.domaci_skore, hoste_skore = o.hoste_skore
            }).ToList();

            return temp;
        }

        public DataTable SelectDomaci(IZapasy _zapasy, int id)
        {
            return _zapasy.SelectPlayersDomaci(id);
        }

        public DataTable SelectHoste(IZapasy _zapasy, int id)
        {
            return _zapasy.SelectPlayersHoste(id);
        }
    }
}
