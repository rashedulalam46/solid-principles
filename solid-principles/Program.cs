using Application;
using SolidPrinciples.Domain;
using SolidPrinciples.Infrastructure;

Order order = new Order { OrderId = "123", Amount = 100.50m };

// Plug in any payment processor & invoice generator
IPaymentProcessor payment = new PayPalPayment();
IInvoiceGenerator invoice = new PdfInvoice();

CheckoutService checkout = new CheckoutService(payment, invoice, new OrderRepository());
checkout.Checkout(order);