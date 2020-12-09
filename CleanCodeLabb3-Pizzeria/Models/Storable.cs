namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum UnitOfMeasure { Gram, Centiliter, Can, Piece }

    public abstract class Storable
    {
        private int _articleNumber;
        private string _name;
        private double _amount;
        private UnitOfMeasure _unit;

        public int ArticleNumber { get => _articleNumber; set => _articleNumber = value; }
        public string Name { get => _name; set => _name = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public UnitOfMeasure Unit { get => _unit; set => _unit = value; }
    }
}
