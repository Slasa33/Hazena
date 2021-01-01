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
        public void InsertKluby(IKluby _ikluby, Kluby kluby)
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
