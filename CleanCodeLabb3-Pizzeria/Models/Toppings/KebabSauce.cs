using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class KebabSauce : Topping
    {
        public KebabSauce()
        {
            ArticleNumber = 12;
            Name = "kebab sauce";
            Amount = 10.0;
            Unit = UnitOfMeasure.Centiliter;
        }
    }
}
