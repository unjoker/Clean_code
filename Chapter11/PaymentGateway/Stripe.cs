using System;

namespace Chapter11.PaymentGateway;

class Stripe : IPaymentGateway
{
    public Result Charge(decimal amount, string toCustomer)
    {
        Console.WriteLine("charge from stripe");
        return Result.Success();
    }
}