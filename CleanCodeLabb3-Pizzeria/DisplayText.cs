using CleanCodeLabb3_Pizzeria.Factories;
using CleanCodeLabb3_Pizzeria.Models;
//using CleanCodeLabb3_Pizzeria.ObserverModels;
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

        CostProvider costProvider = new CostProvider();
        CostObserver accounting = new CostObserver("Accounting");
        PizzaProvider pizzaProvider = new PizzaProvider();
        PizzaObserver bakers = new PizzaObserver("Bakers");
        ResourceProvider resourceProvider = new ResourceProvider();
        ResourceObserver warehouse = new ResourceObserver("Warehouse");


        public void SetObservers()
        {
            accounting.Subscribe(costProvider);
            bakers.Subscribe(pizzaProvider);
            warehouse.Subscribe(resourceProvider);
        }
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
            SetObservers();
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
                    NavigationSwitch();
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
            costProvider.TrackCost(new Data.OutgoingCost(totalCost));
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
                var toppings = new List<Topping>();
                ((Pizza)product).StandardToppings.ForEach(topping => toppings.Add(topping));
                ((Pizza)product).ExtraToppings.ForEach(topping => toppings.Add(topping));
                Console.Write("   Toppings: ");
                for (int i = 0; i < toppings.Count - 1; i++)
                {
                    Console.Write(toppings[i].Name + ", ");
                }
                Console.WriteLine(toppings[toppings.Count - 1].Name);
            }
            Console.WriteLine();
        }

        private void ViewOrders()
        {
            _console.Clear();
            Console.WriteLine("Select order to change status");
            Console.WriteLine("q: Exit");
            Console.WriteLine("Orders:");
            List<Order> activeOrders = GetActiveOrders();
            foreach (var order in GetActiveOrders())
            {
                Console.WriteLine($"{ activeOrders.IndexOf(order) + 1}: Order { activeOrders.IndexOf(order) + 1} Status: {order.CurrentStatus} Cost: {GetTotalOrderCost(order)}:-");
                foreach (var product in order.ProductItems)
                {
                    Console.WriteLine(product.Name);
                }
                Console.WriteLine();
            }
            var input = Console.ReadLine();
            if (int.TryParse(input, out int menuIndex) && menuIndex <= activeOrders.Count)
            {
                ChangeOrderStatus(activeOrders[menuIndex - 1]);
            }
            else if (input == "q")
            {
                NavigationSwitch();
            }
            else
            {
                TryAgainMessage();
                ViewOrders();
            }
        }

        private List<Order> GetActiveOrders()
        {
            List<Order> activeOrders = new List<Order>();
            activeOrders.AddRange(from order in _orders
                                  where order.CurrentStatus == Status.Active
                                  select order);
            return activeOrders;
        }

        private void ChangeOrderStatus(Order order)
        {
            DisplayOrderStatusOptions();
            switch (Console.ReadLine())
            {
                case "1":
                    order.CurrentStatus = Status.Completed;
                    break;
                case "2":
                    order.CurrentStatus = Status.Aborted;
                    break;
                default:
                    TryAgainMessage();
                    ChangeOrderStatus(order);
                    break;
            }
            ViewOrders();
        }

        private void DisplayOrderStatusOptions()
        {
            _console.Clear();
            Console.WriteLine("1: Finish order");
            Console.WriteLine("2: Cancel order");
        }

        private void FinishOrder()
        {
            _orders.Add(_currentOrder);
            DisplayFinishedOrder();
            resourceProvider.EndTransmission();
            pizzaProvider.EndTransmission();
            costProvider.EndTransmission();
            CreateNewOrder();
            NavigationSwitch();
        }

        private void DisplayFinishedOrder()
        {
            _console.Clear();
            Console.WriteLine("The complete order:");
            Console.WriteLine(GetTotalOrderCost(_currentOrder) + ":-");
            foreach (var product in _currentOrderItems)
            {
                Console.WriteLine(product.Name);
                DisplayPizzaToppings(product);
            }
            _console.ReadKey();
        }

        private void AddItemToOrder(OrderItem item)
        {
            _currentOrderItems.Add(_productFactory.Get(item));
        }

        private void NavigationSwitch()
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
                    NavigationSwitch();
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
