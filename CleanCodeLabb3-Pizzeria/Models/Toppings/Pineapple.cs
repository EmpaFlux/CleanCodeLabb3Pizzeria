namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Pineapple : Topping
    {
        public Pineapple()
        {
            PriceGroup = ExtraToppingPriceGroup.A;
            ArticleNumber = 5;
            Name = "pineapple";
            Amount = 50.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
