using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class RozhodciDomain
    {
        public bool GetLogin(string rodne_cislo, string heslo, IRozhodci _rozhodci)
        {
            Rozhodci z = _rozhodci.SelectHeslo(rodne_cislo, heslo);
            if (z == null)
            {
                return false;
            }

            return true;
        }
    }
}
