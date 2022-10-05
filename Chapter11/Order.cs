using System;

namespace Chapter11;

public class Order
{
    public static Order From(ShoppingCart shoppingCart)
    {
        return new Order();
    }

    public bool CanBeFullfilledBy(IWarehouse warehouse)
    {
        return true;
    }

    public string Id { get; set; }

    public void OnCompleted(Action doThis)
    {
        throw new NotImplementedException();
    }
}