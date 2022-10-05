using System.Management.Instrumentation;

namespace Chapter11;

public interface IOrderRepository
{
    void Add(Order order);
    void Remove(Order order);

}