using System;
using System.Collections.Generic;
using System.Text;
using CleanCodeLabb3_Pizzeria.Data;
using CleanCodeLabb3_Pizzeria.Factories;
using CleanCodeLabb3_Pizzeria.Models;
using System.Linq;

namespace CleanCodeLabb3_Pizzeria
{
    public sealed class Menu
    {
        public static Menu Instance = new Menu();
        ProductDatabase productDatabase = ProductDatabase.Instance;
        List<OrderItem> pizzaNames = new List<OrderItem>();
        List<OrderItem> drinkNames = new List<OrderItem>();
        List<OrderItem> toppingNames = new List<OrderItem>();
        List<Product> allMenuItems = new List<Product>();
        List<Topping> extraToppingsMenu = new List<Topping>();
        PizzaFactory pizzaFactory = PizzaFactory.Instance;
        DrinkFactory drinkFactory = DrinkFactory.Instance;
        ToppingFactory toppingFactory = ToppingFactory.Instance;

        private Menu()
        {
            pizzaNames = productDatabase.GetPizzas();
            drinkNames = productDatabase.GetDrinks();
            toppingNames = productDatabase.GetToppings();
            PopulateMenuItems();
        }

        public List<Product> AllMenuItems { get => allMenuItems; }
        public List<Topping> ExtraToppingsMenu { get => extraToppingsMenu; }

        private void PopulateMenuItems()
        {
            pizzaNames.ForEach(pizza => allMenuItems.Add(pizzaFactory.Get(pizza.Name)));
            drinkNames.ForEach(drink => allMenuItems.Add(drinkFactory.Get(drink.Name)));
            ExtraToppingsMenu.AddRange(from topping in toppingNames
                                       let toppingToAdd = toppingFactory.Get(topping.Name)
                                       where toppingToAdd.CanBeAddedAsExtra()
                                       select toppingToAdd);
        }
    }
}
