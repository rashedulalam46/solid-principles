using SolidPrinciples.Domain;

namespace Application;

public class PdfInvoice : IInvoiceGenerator
{
   
    public void GenerateInvoice(Order order)
    {
        Console.WriteLine($"PDF invoice generated for order {order.OrderId}");
    }
}