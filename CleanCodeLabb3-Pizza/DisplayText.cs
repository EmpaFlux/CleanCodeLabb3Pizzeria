using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CleanCodeLabb3_Pizza
{
    class DisplayText
    {
        private static List<string> order = new List<string>();
        static List<string> inventory = new List<string>()
        {
            "Pizza 1",
            "Pizza 2",
            "Pizza 1",
            "Sprite"
        };

        public static void DisplayMenu()
        {
            bool handlingOrder = true;
            while (handlingOrder)
            {
                Console.WriteLine("Select the desired product:");
                foreach (var product in new List<string> { "1: Pizza 1", "2: Pizza 2", "3: Sprite", "", "4: Finish order", "", "5: Check inventory" })
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine();
                Console.WriteLine("Current order items:");
                foreach (var product in order)
                {
                    Console.WriteLine(product);
                }
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        order.Add("Pizza 1");
                        break;
                    case '2':
                        order.Add("Pizza 2");
                        break;
                    case '3':
                        order.Add("Sprite");
                        break;
                    case '4':
                        handlingOrder = false;
                        Console.Clear();
                        Console.WriteLine("The complete order:");
                        foreach (var product in order)
                        {
                            Console.WriteLine(product);
                        }
                        Console.ReadKey();
                        order.Clear();
                        break;
                    case '5':
                        handlingOrder = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Inte bra");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
            SwitchMenu();
            Console.ReadKey();
        }
        static void SwitchMenu()
        {
            Console.WriteLine("New order?");
            foreach (var product in new List<string> { "1: Yes", "2: No, finish", "3: View inventory", "4: View Pizzas in orders" })
            {
                Console.WriteLine(product);
            }
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.Clear();
                    DisplayMenu();
                    break;
                case '2':
                    break;
                case '3':
                    Console.Clear();
                    foreach (var product in inventory)
                    {
                        Console.WriteLine(product);
                    }
                    Console.ReadKey();
                    break;
                case '4':
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Inte bra");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}
