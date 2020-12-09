using CleanCodeLabb3_Pizzeria.Models.Toppings;

namespace CleanCodeLabb3_Pizzeria.Models.Pizza
{
    public class Hawaii : Pizza
    {
        public Hawaii()
        {
            Name = "Hawaii";
            Price = 95;
            StandardToppings.Add(new Ham());
            StandardToppings.Add(new Pineapple());
        }
    }
}
