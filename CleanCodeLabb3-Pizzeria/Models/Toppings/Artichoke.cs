namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Artichoke : Topping
    {
        public Artichoke()
        {
            PriceGroup = ExtraToppingPriceGroup.B;
            ArticleNumber = 8;
            Name = "artichoke";
            Amount = 20.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}

