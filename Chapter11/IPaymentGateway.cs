namespace Chapter11
{
    public interface IPaymentGateway
    {
        Result Charge(decimal amount, string toCustomer);
    }
}