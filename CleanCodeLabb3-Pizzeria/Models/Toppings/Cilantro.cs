namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Cilantro : Topping
    {
        public Cilantro()
        {
            PriceGroup = ExtraToppingPriceGroup.C;
            ArticleNumber = 14;
            Name = "cilantro";
            Amount = 10.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
