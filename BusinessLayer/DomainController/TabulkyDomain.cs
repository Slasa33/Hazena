using System.Collections.Generic;
using System.Linq;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class TabulkyDomain
    {
        private ITabulky _itabulky;

        public TabulkyDomain(ITabulky itabulky)
        {
            _itabulky = itabulky;
        }

        public List<Tabulky> SelectVsechny()
        {
            return _itabulky.VyberVsechny().ToList();
        }
    }
}
