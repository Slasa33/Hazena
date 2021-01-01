using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Persist;
using BusinessLayer.Table;
using DataLayer;

namespace TerminalApp
{
    class Menu
    {

        public void VytvorMenu()
        {
            Console.Clear();
            Console.Write("1 - pro vypis rozhodcich\n2 - pro vypis prezidentu\n3 - pro pridani rozhodciho\n");
        }


        public void Vyber()
        {
            terminalRozhodci rozhodci = new terminalRozhodci();
            terminalPrezident prezident = new terminalPrezident();

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
