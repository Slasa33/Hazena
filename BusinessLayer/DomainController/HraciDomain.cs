using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Modely;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class HraciDomain
    {
        public bool GetLogin(string rodne_cislo, string heslo, IHraci _hraci)
        {
            Hraci z = _hraci.SelectHeslo(rodne_cislo, heslo);
            if (z == null)
            {
                return false;
            }

            return true;
        }

        public void InsertHrac(IHraci _ihraci, Hraci hraci)
        {
            if (hraci.hID == 0)
            {
                _ihraci.Insert(hraci);
            }
            else
            {
                _ihraci.Update(hraci);
            }
        }

        public void DeleteHrac(IHraci _ihraci, Hraci hraci)
        {
            if (hraci.hID != 0)
            {
                _ihraci.Delete(hraci);
            }
        }

        public List<ModelHraci> SelectHraciID(IHraci _ihraci, int id)
        {
            List<Hraci> hraci = new List<Hraci>();
            List<ModelHraci> temp = new List<ModelHraci>();
            hraci = _ihraci.SelectHraci(id).ToList();
            temp = hraci.Select(o => new ModelHraci() {hID = o.hID, jmeno = o.jmeno, prijmeni = o.prijmeni}).ToList();

            return temp;
        }
    }
}
