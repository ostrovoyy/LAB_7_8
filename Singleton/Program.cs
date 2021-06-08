using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen1 = new Citizen();
            Citizen citizen2 = new Citizen();

            citizen1.See("menu1");
            Console.WriteLine(citizen1.Menu.idMenu);

      

            citizen2.See("menu2");
            Console.WriteLine(citizen2.Menu.idMenu);
            Console.ReadLine();
        }
    }

    class Citizen
    {
        public Menu Menu { get; set; }
        public void See(string idMenu)
        {
            Menu = Menu.getInstance(idMenu);
        }
    }

    class Menu
    {
        private static Menu instance;
        public string idMenu { get; private set; }
        private static object syncRoot = new object();

        protected Menu(string id)
        {
            idMenu = id;
        }

        public static Menu getInstance(string id)
        {
            if (instance == null)
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Menu(id);
                }
            return instance;
        }
    }
}
