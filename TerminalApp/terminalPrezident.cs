using System;
using System.Collections.Generic;
using BusinessLayer.Table;
using DataLayer.Items;

namespace TerminalApp
{
    class terminalPrezident
    {
        public void VypisPrezidentu()
        {
            IEnumerable<PrezidentKlubu> prez = PrezidentKlubuSingleton.Instance.SelectArray();
            foreach (var item in prez)
            {
                Console.WriteLine(item);
            }
        }
    }
}
