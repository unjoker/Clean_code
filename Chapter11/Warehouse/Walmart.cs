using System;

namespace Chapter11.Warehouse;

class Walmart : IWarehouse
{
    public void Fullfill(Order order)
    {
        Console.WriteLine("order fullfilled by walmart");
    }
}