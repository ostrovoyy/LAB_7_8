using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuItemCreator creator = new ReportCreator("Creating a report");
            Console.WriteLine("\n" + creator.Name);
            MenuItem dish = creator.Create();

            Console.ReadLine();
        }
    }

    abstract class MenuItemCreator
    {
        public string Name { get; set; }

        public MenuItemCreator(string n)
        {
            Name = n;
        }

        abstract public MenuItem Create();
    }

    class DishCategoryCreator : MenuItemCreator
    {
        public DishCategoryCreator(string n) : base(n)
        { }

        public override MenuItem Create()
        {
            return new Dish();
        }
    }

    class DrinkCategoryCreator : MenuItemCreator
    {
        public DrinkCategoryCreator(string n) : base(n)
        { }

        public override MenuItem Create()
        {
            return new Drink();
        }
    }

    class DessertCategoryCreator : MenuItemCreator
    {
        public DessertCategoryCreator(string n) : base(n)
        { }

        public override MenuItem Create()
        {
            return new Dessert();
        }
    }

    class SnackCategoryCreator : MenuItemCreator
    {
        public SnackCategoryCreator(string n) : base(n)
        { }

        public override MenuItem Create()
        {
            return new Snack();
        }
    }

    abstract class MenuItem
    { }

    class Dish : MenuItem
    {
        public Dish()
        {
            Console.WriteLine("A new dish has been created");
        }
    }

    class Drink : MenuItem
    {
        public Drink()
        {
            Console.WriteLine("A new drink has been created");
        }
    }

    class Dessert : MenuItem
    {
        public Dessert()
        {
            Console.WriteLine("A new dessert has been created");
        }
    }

    class Snack : MenuItem
    {
        public Snack()
        {
            Console.WriteLine("A new snack has been created");
        }
    }
}
