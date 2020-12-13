using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public class OrderItem
    {
        private string _name;
        private OrderItemType _type;

        public OrderItem(OrderItemType type, string name)
        {
            _type = type;
            _name = name;
        }

        public OrderItemType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
