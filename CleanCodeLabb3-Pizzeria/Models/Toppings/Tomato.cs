using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Tomato : Topping
    {
        public Tomato()
        {
            ArticleNumber = 11;
            Name = "tomato";
            Amount = 1.0;
            Unit = UnitOfMeasure.Piece;
        }
    }
}
