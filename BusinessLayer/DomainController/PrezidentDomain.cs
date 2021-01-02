using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class PrezidentDomain
    {
        private IPrezident _iprezident;

        public PrezidentDomain(IPrezident iprezident)
        {
            _iprezident = iprezident;
        }

        public bool GetLogin(string rodne_cislo, string heslo)
        {
            PrezidentKlubu z = _iprezident.SelectHeslo(rodne_cislo, heslo);
            if (z == null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<PrezidentKlubu> SelectAll()
        {
            return _iprezident.SelectArray();
        }
    }
}
