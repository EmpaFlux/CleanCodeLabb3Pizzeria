using CleanCodeLabb3_Pizzeria.Models;
using CleanCodeLabb3_Pizzeria.Models.Toppings;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    public sealed class ToppingFactory
    {
        private string _itemName;
        private ToppingFactory() { }
        public static ToppingFactory ToppingFactoryInstance { get; } = new ToppingFactory();
        public OrderItem Get(string itemName)
        {
            _itemName = itemName;
            return GetTopping();
        }

        private Topping GetTopping()
        {
            Topping topping = new Topping() { Name = _itemName };

            switch (_itemName)
            {
                case "artichoke":
                    topping.PriceGroup = ExtraToppingPriceGroup.B ;
                    break;
                case "cheese":
                    topping.PriceGroup = ExtraToppingPriceGroup.None;
                        break;
                case "cilantro":
                    topping.PriceGroup = ExtraToppingPriceGroup.C;
                    break;
                case "clam":
                    topping.PriceGroup = ExtraToppingPriceGroup.B;
                    break;
                case "ham":
                    topping.PriceGroup = ExtraToppingPriceGroup.A;
                    break;
                case "kebab":
                    topping.PriceGroup = ExtraToppingPriceGroup.C;
                    break;
                case "kebab sauce":
                    topping.PriceGroup = ExtraToppingPriceGroup.A;
                    break;
                case "lettuce":
                    topping.PriceGroup = ExtraToppingPriceGroup.None;
                    break;
                case "mushroom":
                    topping.PriceGroup = ExtraToppingPriceGroup.None;
                    break;
                case "onion":
                    topping.PriceGroup = ExtraToppingPriceGroup.A;
                    break;
                case "peperoncini":
                    topping.PriceGroup = ExtraToppingPriceGroup.None;
                    break;
                case "pineapple":
                    topping.PriceGroup = ExtraToppingPriceGroup.A;
                    break;
                case "shrimp":
                    topping.PriceGroup = ExtraToppingPriceGroup.B;
                    break;
                case "tomato":
                    topping.PriceGroup = ExtraToppingPriceGroup.None;
                    break;
                case "tomato sauce":
                    topping.PriceGroup = ExtraToppingPriceGroup.None;
                    break;
                default:
                    topping = null;
                    break;
            }
            return topping;
        }
    }
}
