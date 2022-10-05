using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Chapter11.AOP.Proxy;

public class LoggingProxy<T>: RealProxy
{
    private T _proxied;

    public LoggingProxy(T proxied):base(typeof(T))
    {
        _proxied = proxied;
    }
    
    public override IMessage Invoke(IMessage msg)
    {
        var methodCall = msg as IMethodCallMessage;
        Log($"In Logging Proxy - Before executing '{methodCall.MethodName}'");
        
        try
        {
            var methodInfo = methodCall.MethodBase as MethodInfo;
            var result = methodInfo.Invoke(_proxied, methodCall.InArgs);
            
            Log($"In Logging Proxy - After executing '{methodCall.MethodName}' ");
            
            return new ReturnMessage(result, null, 0,
                methodCall.LogicalCallContext, methodCall);
        }
        catch (Exception e)
        {
            Log($"In Logging Proxy - Exception {e.Message} executing '{methodCall.MethodName}'");
            return new ReturnMessage(e, methodCall);
        }
    }
    
    private void Log(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}