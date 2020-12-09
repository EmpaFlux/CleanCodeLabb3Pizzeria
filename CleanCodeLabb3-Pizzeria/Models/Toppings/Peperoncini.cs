namespace CleanCodeLabb3_Pizzeria.Models.Toppings
{
    public class Peperoncini : Topping
    {
        public Peperoncini()
        {
            ArticleNumber = 9;
            Name = "peperoncini";
            Amount = 6.0;
            Unit = UnitOfMeasure.Piece;
        }
    }
}
