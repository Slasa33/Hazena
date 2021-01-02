using System;
using System.Collections.Generic;
using BusinessLayer.DomainController;
using DataLayer.Items;
using DataLayer.Interfaces;

namespace TerminalApp
{
    class terminalPrezident
    {

        private readonly IPrezident _prezident;
        private readonly PrezidentDomain _prezidentDomain;

        public terminalPrezident(IPrezident prezident)
        {
            _prezident = prezident;
        }

        public void VypisPrezidentu()
        {
            var prez = _prezidentDomain.SelectAll();
            foreach (var item in prez)
            {
                Console.WriteLine(item);
            }
        }
    }
}
