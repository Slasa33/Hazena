using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Database;
using DataLayer;
using DataLayer.DbTables;
using DataLayer.Interfaces;

namespace TerminalApp
{

    public class Program
    {

        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.Vyber();
        }
    }
}
