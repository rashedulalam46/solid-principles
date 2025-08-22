using SolidPrinciples.Domain;

namespace Application;

public interface IInvoiceGenerator
{
    void GenerateInvoice(Order order);
}