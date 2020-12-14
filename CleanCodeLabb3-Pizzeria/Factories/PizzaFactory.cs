using CleanCodeLabb3_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    public sealed class PizzaFactory : IPizzeriaFactory<Pizza>
    {
        private PizzaFactory() { }
        public static PizzaFactory Instance { get; } = new PizzaFactory();

        public Pizza Get(string pizzaName)
        {
            return GetPizza(pizzaName);
        }

        public List<Pizza> Get(List<string> pizzaNames)
        {
            var pizzas = new List<Pizza>();
            pizzaNames.ForEach(name => pizzas.Add(GetPizza(name)));
            return pizzas;
        }

        private Pizza GetPizza(string pizzaName)
        {
            var toppingFactory = ToppingFactory.Instance;
            Pizza pizza = new Pizza() { Name = pizzaName, StandardToppings = toppingFactory.Get(new List<string>() { "cheese", "tomato sauce" }) };

            switch (pizzaName)
            {
                case "Hawaii":
                    pizza.PriceGroup = PizzaPriceGroup.B;
                    pizza.StandardToppings.AddRange(toppingFactory.Get(new List<string>() { "ham", "pineapple" }));
                    break;
                case "Kebab pizza":
                    pizza.PriceGroup = PizzaPriceGroup.C;
                    pizza.StandardToppings.AddRange(toppingFactory.Get(new List<string>() { "kebab", "mushroom", "onion", "peperoncini", "tomato", "kebab sauce" }));
                    break;
                case "Margerita":
                    pizza.PriceGroup = PizzaPriceGroup.A;
                    break;
                case "Quatro Stagioni":
                    pizza.PriceGroup = PizzaPriceGroup.D;
                    pizza.StandardToppings.AddRange(toppingFactory.Get(new List<string>() { "ham", "shrimp", "clam", "mushroom", "artichoke" }));
                    break;
                default:
                    pizza = null;
                    break;
            }
            return pizza;
        }
    }
}
