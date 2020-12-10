using CleanCodeLabb3_Pizzeria.Models.Toppings;

namespace CleanCodeLabb3_Pizzeria.Models.Pizzas
{
    public class KebabPizza : Pizza
    {
        public KebabPizza()
        {
            Name = "Kebabpizza";
            Price = 105;
            StandardToppings.Add(new Kebab());
            StandardToppings.Add(new Mushroom());
            StandardToppings.Add(new Onion());
            StandardToppings.Add(new Peperoncini());
            StandardToppings.Add(new Tomato());
            StandardToppings.Add(new KebabSauce());
        }
    }
}
