using System;
using System.Collections.Generic;
using System.Threading;
using DataLayer.Items;
using DataLayer.Interfaces;

namespace TerminalApp
{
    class terminalRozhodci
    {

        private readonly IRozhodci _rozhodci;


        public terminalRozhodci(IRozhodci rozhodci)
        {
            _rozhodci = rozhodci;
        }

        public void VypisRozhodcich()
        {
            IEnumerable<Rozhodci> rozhodci = _rozhodci.SelectArray();
            foreach (var item in rozhodci)
            {
                Console.WriteLine(item);
            }
        }

        public static Rozhodci Vloz()
        {
            Console.Write("Vloz jmeno: ");
            string _jmeno = Console.ReadLine();
            Console.Write("Vloz prijmeni: ");
            string _prijmeni = Console.ReadLine();
            Console.Write("Vloz rodne cislo: ");
            string _rodne_cislo = Console.ReadLine();
            Console.Write("Vloz telefon: ");
            string _telefon = Console.ReadLine();
            Console.Write("Vloz heslo: ");
            string _heslo = Console.ReadLine();

            Rozhodci _rozhodci = new Rozhodci
            {
                jmeno = _jmeno,
                prijmeni = _prijmeni,
                rodne_cislo = _rodne_cislo,
                telefon = _telefon,
                heslo = _heslo,
            };

            return _rozhodci;
        }

        public void VlozRozhodcicho()
        {
            Rozhodci roz = Vloz();
            _rozhodci.Insert(roz);
            Console.WriteLine("Rozhodci vlozen!");
            Thread.Sleep(2000);
        }
    }
}
