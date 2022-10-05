using System.Collections.Generic;

namespace Chapter11.AOP.PostSharp;

public class InMemoryOrderRepository:IOrderRepository
{
    private List<Order> _orders = new List<Order>();
    
    [AuthorizationAspect]
    [LoggingAspect]
    public void Add(Order order)
    {
        _orders.Add(order);
    }

    [AuthorizationAspect]
    [LoggingAspect]
    public void Remove(Order order)
    {
        _orders.Remove(order);
    }
}