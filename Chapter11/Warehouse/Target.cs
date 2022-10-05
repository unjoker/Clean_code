using System;

namespace Chapter11.Warehouse;

class Target : IWarehouse
{
    public void Fullfill(Order order)
    {
        Console.WriteLine("order fullfilled by target");
    }
}