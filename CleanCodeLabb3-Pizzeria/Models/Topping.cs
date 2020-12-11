namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum ExtraToppingPriceGroup { None, A = 10, B = 15, C = 20}
    public class Topping : OrderItem
    {
        private ExtraToppingPriceGroup _extraToppingPriceGroup = ExtraToppingPriceGroup.None;

        public bool CanBeAddedAsExtra { get { return !PriceGroup.Equals(ExtraToppingPriceGroup.None); } 
        } 
        public ExtraToppingPriceGroup PriceGroup { get => _extraToppingPriceGroup; set => _extraToppingPriceGroup = value; }
         
        public double ExtraToppingPrice { get => (double)PriceGroup; }
    }
}

