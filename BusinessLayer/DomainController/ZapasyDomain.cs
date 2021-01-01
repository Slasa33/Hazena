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
        private IZapasy _zapasy;

        public ZapasyDomain(IZapasy zapasy)
        {
            _zapasy = zapasy;
        }

        public IEnumerable<ModelZapasy> SelectVsechnyZapasy()
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

        public DataTable SelectDomaci(int id)
        {
            return _zapasy.SelectPlayersDomaci(id);
        }

        public DataTable SelectHoste(int id)
        {
            return _zapasy.SelectPlayersHoste(id);
        }
    }
}
