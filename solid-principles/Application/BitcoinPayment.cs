using SolidPrinciples.Domain;

namespace Application;

public class BitcoinPayment:IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine($"Processing Bitcoin payment for {order.Amount}");
    }
}