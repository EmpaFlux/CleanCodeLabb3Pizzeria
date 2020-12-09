namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Cheese : Topping
    {
        public Cheese()
        {
            ArticleNumber = 1;
            Name = "cheese";
            Amount = 100.0;
            Unit = UnitOfMeasure.Gram;
        }
    }
}
