using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Modely;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class KlubyDomain
    {
        private IKluby _ikluby;

        public KlubyDomain(IKluby ikluby)
        {
            _ikluby = ikluby;
        }

        public void InsertKluby(Kluby kluby)
        {
            if (kluby.kID == 0)
            {
                _ikluby.Insert(kluby);
            }
            else
            {
                _ikluby.Update(kluby);
            }
        }
        public Kluby SelectPodleID(int id)
        {
            return _ikluby.SelectId(id);
        }

        public IEnumerable<ModelKluby> SelectVsechnyZapasy()
        {
            IEnumerable<Kluby> kluby = _ikluby.VyberVsechnyKluby();
            IEnumerable<ModelKluby> temp;

            temp = kluby.Select(o => new ModelKluby()
            {
                kID = o.kID,
                nazev_klubu = o.nazev_klubu,
                prezident_klubu_prezID = o.prezident_klubu_prezID
            }).ToList();

            return temp;
        }
    }
}
