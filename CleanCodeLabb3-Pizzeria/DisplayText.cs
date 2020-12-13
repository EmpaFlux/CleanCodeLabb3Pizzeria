using CleanCodeLabb3_Pizzeria.Factories;
using CleanCodeLabb3_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeLabb3_Pizzeria
{
    public class DisplayText
    {
        List<Order> _orders;
        Order _currentOrder;
        List<Product> _currentOrderItems;
        IConsole _console;
        PizzaFactory _pizzaFactory;
        ProductFactory _productFactory;
        List<Product> _menu;

        public DisplayText(IConsole console)
        {
            _orders = new List<Order>();
            _currentOrder = new Order();
            _currentOrderItems = _currentOrder.ProductItems;
            _console = console;
            _pizzaFactory = PizzaFactory.Instance;
            _productFactory = ProductFactory.Instance;
            _menu = Menu.Instance.AllMenuItems;
        }

        public void DisplayMenu()
        {
            _console.Clear();
            DisplayAvailableProductsInMenu();
            DisplayOptions();
            DisplayCurrentOrder();
            var input = Console.ReadLine();
            if (MatchesPizzaOrDrink(input, out int menuIndex))
            {
                ActOnValidNumberInput(menuIndex);
            }
            else
            {
                ActOnLetterInput(input);
            }
        }

        private void DisplayOptions()
        {
            if (_currentOrderItems.OfType<Pizza>().Count() > 0)
            {
                Console.WriteLine("a: Add extra topping to pizza");
            }
            Console.WriteLine("q: Place this order");
            Console.WriteLine("w: Cancel this order");
            Console.WriteLine("e: View orders");
        }

        private void ActOnValidNumberInput(int menuIndex)
        {
            var product = _menu[menuIndex - 1];
            var orderItem = new OrderItem(product.Type, product.Name);
            AddItemToOrder(orderItem);
            DisplayMenu();
        }

        private void ActOnLetterInput(string input)
        {
            switch (input)
            {
                case "a":
                    if (OrderContainsPizza()) { DisplayExtraToppingMenu(); }
                    else goto default;
                    break;
                case "q":
                    FinishOrder();
                    break;
                case "w":
                    _currentOrderItems.Clear();
                    SwitchMenu();
                    break;
                case "e":
                    ViewOrders();
                    break;
                default:
                    TryAgainMessage();
                    DisplayMenu();
                    break;
            }
        }

        private void DisplayCurrentOrder()
        {
            Console.WriteLine();
            Console.WriteLine($"Current cost: {GetTotalOrderCost(_currentOrder)}:-");
            Console.WriteLine("Current order items:");
            for (int i = 0; i < _currentOrderItems.Count; i++)
            {
                Product product = _currentOrderItems[i];
                Console.WriteLine($"{i + 1}: {product.Name}");
                DisplayPizzaToppings(product);
            }
        }

        private void DisplayExtraToppingMenu()
        {
            _console.Clear();
            Console.WriteLine("Choose which topping to add:");
            Console.WriteLine();
            var extraToppingsMenu = Menu.Instance.ExtraToppingsMenu;
            for (int i = 0; i < extraToppingsMenu.Count; i++)
            {
                var topping = extraToppingsMenu[i];
                Console.WriteLine($"{i + 1}: {topping.Name}: {topping.GetPrice()}");
            } 
            var input = Console.ReadLine();
            if (int.TryParse(input, out int menuIndex) && menuIndex <= extraToppingsMenu.Count)
            {
                DisplayCurrentPizzasInOrder(extraToppingsMenu[menuIndex - 1]);
            }
            else
            {
                TryAgainMessage();
                DisplayExtraToppingMenu();
            }
            DisplayMenu();
        }

        private double GetTotalOrderCost(Order order)
        {
            double totalCost = 0;
            var pizzas = order.ProductItems.OfType<Pizza>().ToList();
            order.ProductItems.ForEach(item => totalCost += item.GetPrice());
            pizzas.ForEach(pizza => pizza.ExtraToppings.ForEach(topping => totalCost += topping.GetPrice()));
            return totalCost;
        }

        private void DisplayCurrentPizzasInOrder(Topping topping)
        {
            _console.Clear();
            Console.WriteLine("Choose which pizza to add the selected topping to:");
            var pizzasInOrder = new List<Pizza>();
            pizzasInOrder.AddRange(from product in _currentOrderItems
                                   where product.Type == OrderItemType.Pizza
                                   select (Pizza)product);
            for (int i = 0; i < pizzasInOrder.Count; i++)
            {
                Pizza pizza = pizzasInOrder[i];
                Console.WriteLine($"{i + 1}: {pizza.Name}");
            }
            AddToppingToPizza(topping, pizzasInOrder);
        }

        private void AddToppingToPizza(Topping topping, List<Pizza> pizzasInOrder)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int menuIndex) && menuIndex <= pizzasInOrder.Count)
            {
                var pizza = pizzasInOrder[menuIndex - 1];
                pizza.ExtraToppings.Add(topping);
            }
            else
            {
                TryAgainMessage(); 
                DisplayCurrentPizzasInOrder(topping);
            }
        }

        private bool MatchesPizzaOrDrink(string input, out int menuIndex)
        {
            return int.TryParse(input, out menuIndex) && menuIndex < _menu.Count && _menu[menuIndex].Type != OrderItemType.Topping;
        }

        private bool OrderContainsPizza()
        {
            return _currentOrderItems.OfType<Pizza>().Count() > 0; 
        }

        private void DisplayAvailableProductsInMenu()
        {
            Console.WriteLine("Select the desired product:");
            
            for (int i = 0; i < _menu.Count; i++)
            {
                Product product = _menu[i];
                if (product.GetType() != typeof(Topping))
                {
                    Console.WriteLine($"{i + 1}: {product.Name}  {product.GetPrice()}:-");
                    DisplayPizzaToppings(product);
                }
            }
        }

        private void DisplayPizzaToppings(Product product)
        {
            if (product.GetType() == typeof(Pizza))
            {
                var toppings = ((Pizza)product).StandardToppings;
                ((Pizza)product).ExtraToppings.ForEach(topping => toppings.Add(topping));
                Console.Write("   Toppings: ");
                for (int i = 0; i < toppings.Count - 1; i++)
                {
                    Console.Write(toppings[i].Name + ", ");
                }
                Console.WriteLine(toppings[^1].Name);
            }
            Console.WriteLine();
        }

        private void ViewOrders()
        {
            _console.Clear();
            Console.WriteLine("Orders:");
            foreach (var order in _orders)
            {
                Console.WriteLine($"Order { _orders.IndexOf(order) + 1}: Status: {order.CurrentStatus}");
                foreach (var product in order.ProductItems)
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
            _orders.Add(_currentOrder);
            DisplayFinishedOrder();
            CreateNewOrder();
            SwitchMenu();
        }

        private void DisplayFinishedOrder()
        {
            _console.Clear();
            Console.WriteLine("The complete order:");
            Console.WriteLine(GetTotalOrderCost(_currentOrder) + ":-");
            foreach (var product in _currentOrderItems)
            {
                Console.WriteLine(product.Name);
            }
            _console.ReadKey();
        }

        private void AddItemToOrder(OrderItem item)
        {
            _currentOrderItems.Add(_productFactory.Get(item));
        }

        private void SwitchMenu()
        {
            _console.Clear();
            Console.WriteLine("Where to now?");
            if (_currentOrderItems.Count > 0)
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
                    TryAgainMessage();
                    SwitchMenu();
                    break;
            }
        }

        private void CreateNewOrder()
        {
            _currentOrder = new Order();
            _currentOrderItems = _currentOrder.ProductItems;
        }

        private void TryAgainMessage()
        {
            _console.Clear();
            Console.WriteLine("Incorrect input, try again");
            _console.ReadKey();
        }
    }
}
