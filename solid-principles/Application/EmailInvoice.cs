using SolidPrinciples.Domain;

namespace Application;

public class EmailInvoice : IInvoiceGenerator
{
    public void GenerateInvoice(Order order)
    {
        Console.WriteLine($"Invoice emailed for order {order.OrderId}");
    }
}