using CleanCodeLabb3_Pizzeria.Factories;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeLabb3_Pizzeria.Models
{
    public enum Status { Aborted, Completed, Active}
    public class Order
    {
        private Status _currentStatus;
        private List<Product> _productItems = new List<Product>();

        public Order()
        {
            CurrentStatus = Status.Active;
        }

        public List<Product> ProductItems { get => _productItems; set => _productItems = value; }
        public Status CurrentStatus { get => _currentStatus; set => _currentStatus = value; }
    }
}
