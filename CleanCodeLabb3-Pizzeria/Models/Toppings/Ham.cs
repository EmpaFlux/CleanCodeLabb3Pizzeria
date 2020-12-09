namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Ham : Topping
    {
        public Ham()
        {
            PriceGroup = ExtraToppingPriceGroup.A;
            ArticleNumber = 3;
            Name = "ham";
            Amount = 100.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
