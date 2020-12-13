using CleanCodeLabb3_Pizzeria.Models;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    public sealed class ToppingFactory: IPizzeriaFactory<Topping>
    {
        private ToppingFactory() { }
        public static ToppingFactory Instance { get; } = new ToppingFactory();

        public Topping Get(string toppingName)
        {
            return GetTopping(toppingName);
        }

        public List<Topping> Get(List<string> toppingNames)
        {
            var toppings = new List<Topping>();
            toppingNames.ForEach(name => toppings.Add(GetTopping(name)));
            return toppings;
        }

        private Topping GetTopping(string toppingName)
        {
            Topping topping = new Topping() { Name = toppingName };

            switch (toppingName)
            {
                case "artichoke":
                    topping.PriceGroup = ExtraToppingPriceGroup.B;
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
                    topping.PriceGroup = ExtraToppingPriceGroup.A;
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
