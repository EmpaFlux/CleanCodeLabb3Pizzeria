namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Clam : Topping
    {
        public Clam()
        {
            PriceGroup = ExtraToppingPriceGroup.B;
            ArticleNumber = 13;
            Name = "clams";
            Amount = 50.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
