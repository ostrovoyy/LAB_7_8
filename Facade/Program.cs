using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            Order order = new Order();
            Purchase purchase = new Purchase();

            MakeOrderFacade makeOrder = new MakeOrderFacade(cart, order, purchase);
            Client client = new Client();
            client.MakeAnOrder(makeOrder);

            Console.ReadLine();
        }
    }

    class Citizen
    {
        public void AddDTPItem()
        {
            Console.WriteLine("Add NewItem");
        }

        public void DeleteDTPItem()
        {
            Console.WriteLine("Delete NewItem");
        }

        public void SaveDTPItems()
        {
            Console.WriteLine("Save NewItems");
        }
    }

    class Order
    {
        public void PlaceOrder()
        {
            Console.WriteLine("Place an order");
        }

        public void ConfirmOrder()
        {
            Console.WriteLine("Confirm an order");
        }
    }

    class Purchase
    {
        public void SetPaymentMethod()
        {
            Console.WriteLine("Set payment method");
        }
    }

    class MakeOrderFacade
    {
        Cart cart;
        Order order;
        Purchase purchase;

        public MakeOrderFacade(Cart c, Order o, Purchase p)
        {
            cart = c;
            order = o;
            purchase = p;
        }

        public void MakeOrder()
        {
            cart.AddMenuItem();
            cart.SaveMenuItems();
            order.PlaceOrder();
            order.ConfirmOrder();
            purchase.SetPaymentMethod();
        }
    }

    class Citizen
    {
        public void MakeAnOrder(MakeOrderFacade facade)
        {
            facade.MakeOrder();
        }
    }
}
