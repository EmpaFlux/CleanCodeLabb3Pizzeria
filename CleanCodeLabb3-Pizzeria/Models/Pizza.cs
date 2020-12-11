using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum PizzaPriceGroup { A = 85, B = 95, C = 105, D = 115 }
    public class Pizza : OrderItem
    {
        private List<Topping> _standardToppings = new List<Topping>();
        private List<Topping> _extraToppings = new List<Topping>();
        private PizzaPriceGroup _pizzaPriceGroup;

        public List<Topping> StandardToppings { get => _standardToppings; set => _standardToppings = value; }
        public List<Topping> ExtraToppings { get => _extraToppings; set => _standardToppings = value; }
       
        public PizzaPriceGroup PriceGroup { get => _pizzaPriceGroup; set => _pizzaPriceGroup = value; }

        public double GetPrice()
        {
            return (double) _pizzaPriceGroup;
        }

        public string PriceToString()
        {
            return GetPrice().ToString("#.##");
        }
    }
}
