using System;

namespace Chapter11.PaymentGateway;

class Paypal : IPaymentGateway
{
    public Result Charge(decimal amount, string toCustomer)
    {
        Console.WriteLine("charged by paypal");
        return Result.Success();
    }
}