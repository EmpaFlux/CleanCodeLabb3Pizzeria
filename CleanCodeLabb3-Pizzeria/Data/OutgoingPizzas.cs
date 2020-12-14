using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Data
{
    public struct OutgoingPizzas
    {
        List<string> piz;

        public OutgoingPizzas(List<string> pizza)
        {
            this.piz = pizza;
        }

        public List<string> ObserverPizza
        { get { return this.piz; } }

    }
}
