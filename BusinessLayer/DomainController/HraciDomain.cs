using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Modely;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class HraciDomain
    {
        private IHraci _ihraci;
        public HraciDomain(IHraci ihraci)
        {
            _ihraci = ihraci;
        }

        public bool GetLogin(string rodne_cislo, string heslo)
        {
            Hraci z = _ihraci.SelectHeslo(rodne_cislo, heslo);
            if (z == null)
            {
                return false;
            }

            return true;
        }

        public void InsertHrac(Hraci hraci)
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

        public void DeleteHrac(Hraci hraci)
        {
            if (hraci.hID != 0)
            {
                _ihraci.Delete(hraci);
            }
        }

        public List<ModelHraci> SelectHraciID(int id)
        {
            List<Hraci> hraci = new List<Hraci>();
            List<ModelHraci> temp = new List<ModelHraci>();
            hraci = _ihraci.SelectHraci(id).ToList();
            temp = hraci.Select(o => new ModelHraci() {hID = o.hID, jmeno = o.jmeno, prijmeni = o.prijmeni}).ToList();

            return temp;
        }
    }
}
