using CleanCodeLabb3_Pizzeria.Factories;
using CleanCodeLabb3_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CleanCodeLabb3_Pizzeria
{
    public class DisplayText
    {
        public List<OrderItem> currentOrder = new List<OrderItem>();
        public List<List<OrderItem>> orders = new List<List<OrderItem>>();
        IConsole _console;
        PizzaFactory _pizzaFactory = PizzaFactory.PizzaFactoryInstance;

        public DisplayText(IConsole console)
        {
            _console = console;
        }

        public void DisplayMenu()
        {
            _console.Clear();
            DisplayAvailableItemsInMenu();
            Console.WriteLine();
            Console.WriteLine("q: Finish order");
            Console.WriteLine("w: Cancel order");
            Console.WriteLine("e: View current orders");
            Console.WriteLine();
            Console.WriteLine("Current order items:");
            foreach (var product in currentOrder)
            {
                Console.WriteLine(product.Name);
            }
            switch (Console.ReadLine())
            {
                case "1":
                    AddItemToOrder(_pizzaFactory.Get("Hawaii"));
                    break;
                case "2":
                    AddItemToOrder(_pizzaFactory.Get("Kebab pizza"));
                    break;
                case "3":
                    AddItemToOrder(_pizzaFactory.Get("Margerita"));
                    break;
                case "4":
                    AddItemToOrder(_pizzaFactory.Get("Quatro Stagioni"));
                    break;
                case "q":
                    FinishOrder();
                    break;
                case "w":
                    currentOrder.Clear();
                    SwitchMenu();
                    break;
                case "e":
                    ViewOrders();
                    break;
                default:
                    _console.Clear();
                    Console.WriteLine("Try again");
                    _console.ReadKey();
                    DisplayMenu();
                    break;
            }
        }

        private void DisplayAvailableItemsInMenu()
        {
            Console.WriteLine("Select the desired product:");
            List<string> pizzasOnMenu = new List<string>()
            {
                "Hawaii",
                "Kebab pizza",
                "Margerita",
                "Quatro Stagioni"
            };
            var menu = _pizzaFactory.Get(pizzasOnMenu);
            for (int i = 0; i < menu.Count; i++)
            {
                Console.Write($"{i + 1}: {menu[i].Name}");
                if (menu[i].GetType() == typeof(Pizza))
                {
                    Console.Write("         Toppings: ");
                    foreach (var topping in menu[i].StandardToppings)
                    {
                        Console.Write(topping.Name + ", ");
                    }
                }
                Console.WriteLine();
            }
        }

        private void ViewOrders()
        {
            _console.Clear();
            Console.WriteLine("Orders:");
            foreach (var order in orders)
            {
                foreach (var product in order)
                {
                    Console.WriteLine(product.Name);
                }
                Console.WriteLine();
            }
            _console.ReadKey();
            SwitchMenu();
        }

        private void FinishOrder()
        {
            List<OrderItem> tempOrder = new List<OrderItem>();
            foreach (var product in currentOrder)
            {
                tempOrder.Add(product);
            }
            orders.Add(tempOrder);
            _console.Clear();
            Console.WriteLine("The complete order:");
            foreach (var product in currentOrder)
            {
                Console.WriteLine(product.Name);
            }
            _console.ReadKey();
            currentOrder.Clear();
            SwitchMenu();
        }

        private void AddItemToOrder(OrderItem item)
        {
            currentOrder.Add(item);
            DisplayMenu();
        }

        private void SwitchMenu()
        {
            _console.Clear();
            Console.WriteLine("Where to now?");
            if (currentOrder.Count > 0)
            {
                Console.WriteLine("1: Back to order screen");
            }
            else
            {
                Console.WriteLine("1: New order");
            }
            Console.WriteLine("2: Shut down");
            switch (Console.ReadLine())
            {
                case "1":
                    DisplayMenu();
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Try again");
                    _console.ReadKey();
                    _console.Clear();
                    SwitchMenu();
                    break;
            }
        }
    }
}
