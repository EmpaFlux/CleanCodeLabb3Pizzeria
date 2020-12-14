using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum DrinkPriceGroup { A = 20, B = 25}
    public class Drink : Product
    {
        private OrderItemType _type = OrderItemType.Drink;
        private DrinkPriceGroup _drinkPriceGroup;

        public Drink()
        {
            Type = OrderItemType.Drink;
        }

        public DrinkPriceGroup PriceGroup { get => _drinkPriceGroup; set => _drinkPriceGroup = value; }

        public override double GetPrice() { return (double)PriceGroup; }
    }
}
