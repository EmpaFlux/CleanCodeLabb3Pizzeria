using CleanCodeLabb3_Pizzeria.Models.Toppings;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models.Pizzas
{
    public class QuatroStagioni : Pizza
    {
        public QuatroStagioni()
        {
            Name = "Quatro Stagioni";
            Price = 115;
            StandardToppings.Add(new Ham());
            StandardToppings.Add(new Shrimp());
            StandardToppings.Add(new Clam());
            StandardToppings.Add(new Mushroom());
            StandardToppings.Add(new Artichoke());
        }
    }
}
