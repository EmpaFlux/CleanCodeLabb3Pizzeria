using System;
using System.Collections.Generic;
using System.Text;
using CleanCodeLabb3_Pizzeria.Models.Toppings;

namespace CleanCodeLabb3_Pizzeria.Models.Pizzas
{
    public class Pizza : OrderItem
    {
        private List<Topping> _standardToppings = new List<Topping>() { new TomatoSauce(), new Cheese() };
        private List<Topping> _extraToppings = new List<Topping>();

        public List<Topping> StandardToppings { get => _standardToppings; set => _standardToppings = value; }
        public List<Topping> ExtraToppings { get => _extraToppings; set => _standardToppings = value; }
        public string PriceToString()
        {
            return Price.ToString("#.##");
        }
    }
}
