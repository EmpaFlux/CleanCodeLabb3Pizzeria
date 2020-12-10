namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum UnitOfMeasure { Gram, Centiliter, Can, Piece }

    public abstract class Storable: OrderItem
    {
        private int _articleNumber;
        private double _amount;
        private UnitOfMeasure _unit;

        public int ArticleNumber { get => _articleNumber; set => _articleNumber = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public UnitOfMeasure Unit { get => _unit; set => _unit = value; }
    }
}
