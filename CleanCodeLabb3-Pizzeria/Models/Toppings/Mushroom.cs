using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Mushroom : Topping
    {
        public Mushroom()
        {
            ArticleNumber = 4;
            Name = "mushroom";
            Amount = 40.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
