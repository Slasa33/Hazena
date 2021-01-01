using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Abstract;
using DataLayer.Database;
using BusinessLayer.Table;
using DataLayer;

namespace TerminalApp
{

    public class Program
    {

        public static void VytvorMenu()
        {
            Console.Clear();
            Console.Write("1 - pro prihlaseni jako rozhodci\n2 - pro prihlaseni jako prezident\n3 - pro prihlaseni jako hrac\n");
        }

        public static void ZavolejMenu()
        {
            var menu = new Menu();
            menu.Vyber();
        }
        static void Main(string[] args)
        {

          // const string sqlCon = @"data source = localhost\SQLEXPRESS; initial catalog = VIS; integrated security = SSPI";
            var db = new Databaze();

            VytvorMenu();

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
                            Console.Write("Zadej rodne cislo: ");
                            string rodneR = Console.ReadLine();
                            Console.Write("Zadej heslo: ");
                            string hesloR = Console.ReadLine();

                            var zR = RozhodciSingleton.Instance.SelectHeslo(rodneR, hesloR);
                            if (zR == null)
                            {
                                Console.WriteLine("Nespravne udaje!");
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Uspesne prihlasen!");
                            Console.ReadKey();
                            ZavolejMenu();
                            break;

                        case 50:
                            Console.Write("Zadej rodne cislo: ");
                            string rodneP = Console.ReadLine();
                            Console.Write("Zadej heslo: ");
                            string hesloP = Console.ReadLine();

                            var zP = PrezidentKlubuSingleton.Instance.SelectHeslo(rodneP, hesloP);
                            if (zP == null)
                            {
                                Console.WriteLine("Nespravne udaje!");
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Uspesne prihlasen!");
                            Console.ReadKey();
                            ZavolejMenu();
                            break;
                        case 51:
                            Console.Write("Zadej rodne cislo: ");
                            string rodneH = Console.ReadLine();
                            Console.Write("Zadej heslo: ");
                            string hesloH = Console.ReadLine();

                            var zH = HraciSingleton.Instance.SelectHeslo(rodneH, hesloH);
                            if (zH == null)
                            {
                                Console.WriteLine("Nespravne udaje!");
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("Uspesne prihlasen!");
                            Console.ReadKey();
                            ZavolejMenu();
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
