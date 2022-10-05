using System;
using System.Collections.Generic;

namespace Chapter11.AOP.Proxy;

public class InMemoryOrderRepository:IOrderRepository
{
    private List<Order> _orders = new List<Order>();
    public void Add(Order order)
    {
        _orders.Add(order);
    }

    public void Remove(Order order)
    {
        _orders.Remove(order);
    }
}