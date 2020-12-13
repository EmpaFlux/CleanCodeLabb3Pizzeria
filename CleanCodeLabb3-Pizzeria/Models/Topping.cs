namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum ExtraToppingPriceGroup { None, A = 10, B = 15, C = 20}

    public class Topping : Product
    {
        private ExtraToppingPriceGroup _extraToppingPriceGroup;

        public Topping()
        {
            Type = OrderItemType.Topping;
        }
       
        public ExtraToppingPriceGroup PriceGroup { get => _extraToppingPriceGroup; set => _extraToppingPriceGroup = value; }

        public bool CanBeAddedAsExtra() { return !PriceGroup.Equals(ExtraToppingPriceGroup.None); } 

        public override double GetPrice() { return (double)_extraToppingPriceGroup; }
    }
}

