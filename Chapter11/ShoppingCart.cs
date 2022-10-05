using System.Collections.Generic;

namespace Chapter11
{
    public class ShoppingCart
    {
        public string Customer;
        public List<(int qty, string item)> Items = new();
        public decimal Total;
    }
}