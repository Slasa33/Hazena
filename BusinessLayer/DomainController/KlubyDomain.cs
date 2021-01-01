using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
