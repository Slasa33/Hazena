using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.DbTables;
using DataLayer.Interfaces;

namespace TerminalApp
{
    class Menu
    {

        private readonly IRozhodci _rozhodci;
        private readonly IPrezident _prezident;


        public Menu()
        {
            _rozhodci = new DbRozhodci();
            _prezident = new DbPrezident();
        }


        public void VytvorMenu()
        {
            Console.Clear();
            Console.Write("1 - pro vypis rozhodcich\n2 - pro vypis prezidentu\n3 - pro pridani rozhodciho\n");
        }


        public void Vyber()
        {
            terminalRozhodci rozhodci = new terminalRozhodci(_rozhodci);
            terminalPrezident prezident = new terminalPrezident(_prezident);

            Console.Clear();
            Console.Write("1 - pro vypis rozhodcich\n2 - pro vypis prezidentu\n3 - pro pridani rozhodciho\n");
            int switchNum = 0;
            int switchNumBkup = switchNum;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switchNumBkup = switchNum;
                    switchNum = key.KeyChar;
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    switch (switchNum)
                    {
                        case 49:
                            rozhodci.VypisRozhodcich();
                            Console.ReadKey();
                            VytvorMenu();
                            break;

                        case 50:
                            prezident.VypisPrezidentu();
                            Console.ReadKey();
                            VytvorMenu();
                            break;

                        case 51:
                            rozhodci.VlozRozhodcicho();
                            Console.ReadKey();
                            VytvorMenu();
                            break;

                        default:
                            Console.WriteLine("Nespravna moznost!");
                            switchNum = switchNumBkup;
                            break;
                    }
                }
            }
        }
    }
}
