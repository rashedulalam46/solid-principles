using SolidPrinciples.Domain;

namespace Application;

public class PayPalPayment : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine($"Processing PayPal payment for {order.Amount}");
    }
}