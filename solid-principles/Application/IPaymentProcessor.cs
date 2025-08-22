using SolidPrinciples.Domain;

namespace Application;

public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}