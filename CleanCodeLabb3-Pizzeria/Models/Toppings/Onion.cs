namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Onion : Topping
    {
        public Onion()
        {
            PriceGroup = ExtraToppingPriceGroup.A;
            ArticleNumber = 7;
            Name = "onion";
            Amount = 40.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
