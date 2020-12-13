using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum PizzaPriceGroup { A = 85, B = 95, C = 105, D = 115 }

    public class Pizza : Product
    {
        private OrderItemType _type = OrderItemType.Pizza;
        private List<Topping> _standardToppings = new List<Topping>();
        private List<Topping> _extraToppings = new List<Topping>();
        private PizzaPriceGroup _priceGroup;

        public List<Topping> StandardToppings { get => _standardToppings; set => _standardToppings = value; }
        public List<Topping> ExtraToppings { get => _extraToppings; set => _standardToppings = value; }
        public PizzaPriceGroup PriceGroup { get => _priceGroup; set => _priceGroup = value; }
        public OrderItemType Type { get => _type; }
        public override double GetPrice() { return (double)_priceGroup; }
    }
}
