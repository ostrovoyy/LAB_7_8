using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    abstract class Dessert
    {
        public Dessert(string n)
        {
           Name = n;
        }

        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class Tiramisu : Dessert
    {
        public Tiramisu() : base("Tiramisu")
        { }

        public override int GetCost()
        {
            return 71;
        }
    }

    class Cheesecake : Dessert
    {
        public Cheesecake() : base("Cheesecake")
        { }

        public override int GetCost()
        {
            return 59;
        }
    }

    class Pie : Dessert
    {
        public Pie() : base("Pie")
        { }

        public override int GetCost()
        {
            return 45;
        }
    }

    abstract class DessertDecorator : Dessert
    {
        protected Dessert dessert;
        public DessertDecorator(string n, Dessert des) : base(n)
        {
            dessert = des;
        }
    }

    class MondayAndWednesdayDessert : DessertDecorator
    {
        public MondayAndWednesdayDessert(Dessert dessert) :
            base(dessert.Name + " on Monday and Wednesday",dessert)
        { }
        public override int GetCost()
        {
            return (int)(dessert.GetCost() * 0.8);
        }
    }

    class FridayAndSundayDessert : DessertDecorator
    {
        public FridayAndSundayDessert(Dessert dessert) :
            base(dessert.Name + " on Friday and Sunday", dessert)
        { }
        public override int GetCost()
        {
            return (int)(dessert.GetCost() * 0.7);
        }
    }
}
