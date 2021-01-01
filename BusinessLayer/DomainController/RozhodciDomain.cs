using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class RozhodciDomain
    {
        private IRozhodci _irozhodci;

        public RozhodciDomain(IRozhodci irozhodci)
        {
            _irozhodci = irozhodci;
        }

        public bool GetLogin(string rodne_cislo, string heslo)
        {
            Rozhodci z = _irozhodci.SelectHeslo(rodne_cislo, heslo);
            if (z == null)
            {
                return false;
            }

            return true;
        }
    }
}
