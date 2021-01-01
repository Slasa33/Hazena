using System.Collections.Generic;
using System.Linq;
using DataLayer.Interfaces;
using DataLayer.Items;

namespace BusinessLayer.DomainController
{
    public class TabulkyDomain
    {
        public List<Tabulky> SelectVsechny(ITabulky _tabulky)
        {
            return _tabulky.VyberVsechny().ToList();
        }
    }
}
