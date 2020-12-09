namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class TomatoSauce: Topping
    {
        public TomatoSauce()
        {
            ArticleNumber = 2;
            Name = "tomato sauce";
            Amount = 50.0;
            Unit = UnitOfMeasure.Centiliter;
        }
    }
}
