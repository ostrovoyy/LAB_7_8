using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportItem[] rIt1 = new ReportItem[]
            {
                new ReportItem(){District="Borshch",Damage=70},
                new ReportItem(){District="Soup",Damage=50},
                new ReportItem(){District="Jellied meat",Damage=90},
            };
            ReportItem[] rIt2 = new ReportItem[]
            {
                new ReportItem(){District="Tea",Damage=30},
                new ReportItem(){District="Coffee",Damage=45},
                new ReportItem(){District="Cacao",Damage=35},
            };
            Report report = new Report(rIt1,rIt2);
            Client client = new Client();
            client.SeeReportItems(menu);

            Console.ReadLine();
        }
    }

    class Client
    {
        public void SeeReportItems(Report report)
        {
            IDistrictIterator iterator = report.CreateNumerator();
            while (iterator.HasNext())
            {
                District district = iterator.Next();
                Console.WriteLine("\n"+district.Name);
                IReportItemIterator iterator1 = category.CreateNumerator();
                while (iterator1.HasNext())
                {
                    ReportItem menuItem = iterator1.Next();
                    Console.WriteLine(menuItem.Name + ", price: " + menuItem.Price);
                }
            } 
        }
    }
    interface IReportItemIterator
    {
        bool HasNext();
        ReprotItem Next();
    }
    interface IMenuItemNumerable
    {
        IMenuItemIterator CreateNumerator();
        int Count { get; }
        MenuItem this[int index] { get; }
    }

    interface ICategoryIterator
    {
        bool HasNext();
        Category Next();
    }
    interface ICategoryNumerable
    {
        ICategoryIterator CreateNumerator();
        int Count { get; }
        Category this[int index] { get; }
    }

    class MenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    class Category : IMenuItemNumerable
    {
        public string Name { get; set; }
        private MenuItem[] menuItems;

        public Category(string name, MenuItem[] menuIt)
        {
            Name = name;
            menuItems = new MenuItem[menuIt.Length];
            for (int i = 0; i < menuIt.Length; i++)
                menuItems[i] = menuIt[i];
        }
        public int Count
        {
            get { return menuItems.Length; }
        }
        public MenuItem this[int index]
        {
            get { return menuItems[index]; }
        }
        public IMenuItemIterator CreateNumerator()
        {
            return new CategoryNumerator(this);
        }
    }

    class CategoryNumerator : IMenuItemIterator
    {
        IMenuItemNumerable aggregate;
        int index = 0;
        public CategoryNumerator(IMenuItemNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public MenuItem Next()
        {
            return aggregate[index++];
        }
    }

    class Menu : ICategoryNumerable
    {
        public Category[] Categories;
        public Menu(MenuItem[] mIt1, MenuItem[] mIt2)
        {
            Categories = new Category[]
            {
                    new Category("Dishes",mIt1),
                    new Category("Drinks",mIt2)
            };
        }
        public int Count
        {
            get { return Categories.Length; }
        }
        public Category this[int index]
        {
            get { return Categories[index]; }
        }
        public ICategoryIterator CreateNumerator()
        {
            return new MenuNumerator(this);
        }
    }

    class MenuNumerator : ICategoryIterator
    {
        ICategoryNumerable aggregate;
        int index = 0;
        public MenuNumerator(ICategoryNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Category Next()
        {
            return aggregate[index++];
        }
    }
}
