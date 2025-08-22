using SolidPrinciples.Domain;

namespace Application
{
    public class CreditCardPayment : IPaymentProcessor
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine($"Processing Credit Card payment for {order.Amount}");
        }
    }
}
