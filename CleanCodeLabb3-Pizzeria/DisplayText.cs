using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CleanCodeLabb3_Pizzeria
{
    public class DisplayText
    {
        public List<string> currentOrder = new List<string>();
        List<string> inventory = new List<string>()
        {
            "Pizza 1",
            "Pizza 2",
            "Pizza 1",
            "Sprite"
        };
        public List<List<string>> orders = new List<List<string>>();
        IConsole _console;

        public DisplayText(IConsole console)
        {
            _console = console;
        }

        public void DisplayMenu()
        {
            _console.Clear();
            Console.WriteLine("Select the desired product:");
            foreach (var product in new List<string> { "1: Pizza 1", "2: Pizza 2", "3: Sprite" })
            {
                if (inventory.Contains(product.Substring(3)))
                {
                    Console.WriteLine(product);
                }
            }
            Console.WriteLine("4: Finish order");
            Console.WriteLine("5: Cancel order");
            Console.WriteLine("6: View current orders");
            Console.WriteLine();
            Console.WriteLine("Current order items:");
            foreach (var product in currentOrder)
            {
                Console.WriteLine(product);
            }
            switch (Console.ReadLine())
            {
                case "1":
                    AddItemToOrder("Pizza 1");
                    break;
                case "2":
                    AddItemToOrder("Pizza 2");
                    break;
                case "3":
                    AddItemToOrder("Sprite");
                    break;
                case "4":
                    FinishOrder();
                    break;
                case "5":
                    currentOrder.Clear();
                    SwitchMenu();
                    break;
                case "6":
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

        private void ViewOrders()
        {
            _console.Clear();
            Console.WriteLine("Orders:");
            foreach (var order in orders)
            {
                foreach (var product in order)
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
            }
            _console.ReadKey();
            SwitchMenu();
        }

        private void FinishOrder()
        {
            List<string> tempOrder = new List<string>();
            foreach (var product in currentOrder)
            {
                tempOrder.Add(product);
            }
            orders.Add(tempOrder);
            _console.Clear();
            Console.WriteLine("The complete order:");
            foreach (var product in currentOrder)
            {
                Console.WriteLine(product);
            }
            _console.ReadKey();
            currentOrder.Clear();
            SwitchMenu();
        }

        private void AddItemToOrder(string item)
        {
            currentOrder.Add(item);
            DisplayMenu();
        }

        private void SwitchMenu()
        {
            _console.Clear();
            Console.WriteLine("Where to now?");
            Console.WriteLine("1: New order");
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
