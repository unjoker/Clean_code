using System;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Chapter11.AOP.PostSharp;

[PSerializable]
public class AuthorizationAspect:OnMethodBoundaryAspect
{
    public override void OnEntry(MethodExecutionArgs args)
    {
        Log($"In Auth Aspect - Before executing '{args.Method.Name}'");
    }

    public override void OnExit(MethodExecutionArgs args)
    {
        Log($"In Auth Aspect - After executing '{args.Method.Name}' ");
    }

    public override void OnException(MethodExecutionArgs args)
    {
        Log($"In Auth Aspect - Exception {args.Exception.Message} executing '{args.Method.Name}'");
    }

    private void Log(string msg)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}