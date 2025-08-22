using SolidPrinciples.Domain;
using SolidPrinciples.Infrastructure;

namespace Application;

public class CheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;
    private readonly IInvoiceGenerator _invoiceGenerator;
    private readonly OrderRepository _orderRepository;

    public CheckoutService(IPaymentProcessor paymentProcessor, IInvoiceGenerator invoiceGenerator, OrderRepository orderRepository)
    {
        _paymentProcessor = paymentProcessor;
        _invoiceGenerator = invoiceGenerator;
        _orderRepository = orderRepository;
    }

    public void Checkout(Order order)
    {
        _paymentProcessor.ProcessPayment(order);
        _invoiceGenerator.GenerateInvoice(order);
        _orderRepository.Save(order);
    }
}