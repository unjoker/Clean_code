using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Chapter11
{
    public class OrderProcessingApplication
    {
        private IPaymentGateway _paymentGateway;
        private IWarehouse _warehouse;
        private IOrderRepository _trackedOrders;
        public OrderProcessingApplication(IPaymentGateway paymentGateway, IWarehouse warehouse, IOrderRepository trackedOrders)
        {
            _paymentGateway = paymentGateway;
            _warehouse = warehouse;
            _trackedOrders = trackedOrders;
        }

        public Result CreateOrder(ShoppingCart shoppingCart)
        {
            try
            {
                var order = Order.From(shoppingCart);
                
                if (!order.CanBeFullfilledBy(_warehouse))
                  throw new Exception($"{order} can't be fullfilled");
                
                _paymentGateway.Charge(amount: shoppingCart.Total, shoppingCart.Customer);
                
                _trackedOrders.Add(order);
                
                _warehouse.Fullfill(order);
                
                return Result.Success();
                
            }
            catch (Exception exception)
            {
                Log(exception);
                return Result.Fail(exception.Message);

            }
        }

        private void Log(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
    }
}