using System;
using System.Collections.Generic;
using DataLayer.Items;
using DataLayer.Interfaces;

namespace TerminalApp
{
    class terminalPrezident
    {

        private readonly IPrezident _prezident;

        public terminalPrezident(IPrezident prezident)
        {
            _prezident = prezident;
        }

        public void VypisPrezidentu()
        {
            IEnumerable<PrezidentKlubu> prez = _prezident.SelectArray();
            foreach (var item in prez)
            {
                Console.WriteLine(item);
            }
        }
    }
}
