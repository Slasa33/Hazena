using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class PrezidentDomain
    {
        public bool GetLogin(string rodne_cislo, string heslo, IPrezident _prezident)
        {
            PrezidentKlubu z = _prezident.SelectHeslo(rodne_cislo, heslo);
            if (z == null)
            {
                return false;
            }

            return true;
        }
    }
}
