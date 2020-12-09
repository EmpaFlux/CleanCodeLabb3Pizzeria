namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Kebab : Topping
    {
        public Kebab()
        {
            PriceGroup = ExtraToppingPriceGroup.C;
            ArticleNumber = 6;
            Name = "kebab";
            Amount = 50.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
