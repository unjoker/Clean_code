namespace Chapter11.AOP.Proxy;

public class OrderRepositoryFactory
{
    public IOrderRepository Create(string type)
    {
        var repo = new InMemoryOrderRepository();
        return AuthProxy(LoggingProxy(repo));
    }
    
    
    private static IOrderRepository AuthProxy(IOrderRepository repo)
    {
        return new AuthorizationProxy<IOrderRepository>(repo).GetTransparentProxy() as IOrderRepository;
    }

    private static IOrderRepository LoggingProxy(IOrderRepository repo)
    {
        return new LoggingProxy<IOrderRepository>(repo).GetTransparentProxy() as IOrderRepository;
    }
}