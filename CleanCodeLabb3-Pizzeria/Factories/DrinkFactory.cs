using CleanCodeLabb3_Pizzeria.Models;
using System.Collections.Generic;

namespace CleanCodeLabb3_Pizzeria.Factories
{
    public class DrinkFactory : IPizzeriaFactory<Drink>
    {
        private DrinkFactory() { }
        public static DrinkFactory Instance { get; } = new DrinkFactory();

        public Drink Get(string drinkName)
        {
            return GetDrink(drinkName);
        }

        public List<Drink> Get(List<string> drinkNames)
        {
            var drinks = new List<Drink>();
            drinkNames.ForEach(name => drinks.Add(GetDrink(name)));
            return drinks;
        }

        private Drink GetDrink(string name)
        {
            Drink drink = new Drink() { Name = name };

            switch (name)
            {
                case "Coca-Cola":
                    drink.PriceGroup = DrinkPriceGroup.A;
                    break;
                case "Fanta":
                    drink.PriceGroup = DrinkPriceGroup.A;
                    break;
                case "Sprite":
                    drink.PriceGroup = DrinkPriceGroup.B;
                    break;
                default:
                    drink = null;
                    break;
            }
            return drink;
        }
    }
}
