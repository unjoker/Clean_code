using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Chapter11.AOP.Proxy;

public class AuthorizationProxy<T>: RealProxy
{
    private T _proxied;

    public AuthorizationProxy(T proxied):base(typeof(T))
    {
        _proxied = proxied;
    }

    public override IMessage Invoke(IMessage msg)
    {
        var methodCall = msg as IMethodCallMessage;
        var methodInfo = methodCall.MethodBase as MethodInfo;
        Log($"In Auth Proxy - Before executing '{methodCall.MethodName}'");
        try
        {
            var result = methodInfo.Invoke(_proxied, methodCall.InArgs);
            Log($"In Auth Proxy - After executing '{methodCall.MethodName}' ");
            return new ReturnMessage(result, null, 0,
                methodCall.LogicalCallContext, methodCall);
        }
        catch (Exception e)
        {
            Log($"In Auth Proxy- Exception {e.Message} executing '{methodCall.MethodName}'");
            return new ReturnMessage(e, methodCall);
        }
    }
    
    private void Log(string msg)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}