using System;
using System.Collections.Generic;
using Chapter11.AOP.PostSharp;
using Chapter11.AOP.Proxy;
using Chapter11.PaymentGateway;
using Chapter11.Warehouse;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;

namespace Chapter11
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            var repo = new AOP.PostSharp.InMemoryOrderRepository();
            //var repo = new OrderRepositoryFactory().Create(args.Length >= 1 ? args[0] : string.Empty);
            
            var paymentMethod = PaymentMethod(args.Length >= 2 ? args[1] : string.Empty);
            
            var warehouse = Warehouse(args.Length >= 3 ? args[2] : string.Empty);

            var app = new OrderProcessingApplication(paymentMethod, warehouse, repo);

            var builder = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(new string[]{});

            var appHost = builder.Build();
           builder.ConfigureAppConfiguration((a,b)=>b.)
            var shoppingCart = new ShoppingCart
            {
                Customer = "123456",
                Items = new List<(int qty, string item)>
                {
                    (1,"shampoo")
                }
            };
            
            var result = app.CreateOrder(shoppingCart);
        }

        private static IWarehouse Warehouse(string args)
        {
            return args == "walmart" ? new Walmart() : new Target();
        }

        private static IPaymentGateway PaymentMethod(string args)
        {
          return args == "paypal" ? new Paypal() : new Stripe();
        }
    }
}