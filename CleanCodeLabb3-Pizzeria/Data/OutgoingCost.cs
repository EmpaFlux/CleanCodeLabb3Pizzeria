using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Data
{
    public struct OutgoingCost
    {
        double cos;

        public OutgoingCost(double cost)
        {
            this.cos = cost;
        }

        public double ObserverCost
        { get { return this.cos; } }

    }
}
