SOLID Principales




---
# 💳 SOLID Principles in C# – Payment Processing Example

This project demonstrates how to apply the **SOLID principles** in a simple **Payment Processing System** using C#.  
The goal is to show how following SOLID makes code **cleaner, maintainable, and extensible**.

---

## 📖 Overview
The system processes orders using different payment methods and generates invoices.  
It applies all **five SOLID principles**:

1. **Single Responsibility Principle (SRP)**  
   Each class has one responsibility.  
   - `OrderRepository` → Saves orders  
   - `PdfInvoice` / `EmailInvoice` → Generate invoices  
   - `CheckoutService` → Manages checkout process  

2. **Open/Closed Principle (OCP)**  
   The system is open for extension but closed for modification.  
   - New payment methods (e.g., `CreditCardPayment`, `PayPalPayment`, `BitcoinPayment`) can be added without changing existing code.  

3. **Liskov Substitution Principle (LSP)**  
   Subclasses can replace their parent classes without breaking behavior.  
   - Any `IPaymentProcessor` (Credit Card, PayPal, Bitcoin) can be used in `CheckoutService`.  

4. **Interface Segregation Principle (ISP)**  
   Clients are not forced to implement methods they don’t use.  
   - `IInvoiceGenerator` is separate from `IPaymentProcessor`.  

5. **Dependency Inversion Principle (DIP)**  
   High-level modules depend on abstractions, not concrete implementations.  
   - `CheckoutService` depends on `IPaymentProcessor` and `IInvoiceGenerator` interfaces.  

---


## 🚀 Example Run

```csharp
Order order = new Order { OrderId = "123", Amount = 100.50m };

// Choose payment and invoice types
IPaymentProcessor payment = new PayPalPayment();
IInvoiceGenerator invoice = new PdfInvoice();

// Inject dependencies into CheckoutService
CheckoutService checkout = new CheckoutService(payment, invoice, new OrderRepository());

// Process checkout
checkout.Checkout(order);
```

## Output
```csharp
Processing PayPal payment for 100.50
PDF invoice generated for order 123
Order 123 saved to database.
```
## 🔴 Breaking OCP (not open for extension, but modification)
```csharp
public class PaymentProcessor
{
    public void ProcessPayment(Order order, string paymentType)
    {
        if (paymentType == "CreditCard")
        {
            Console.WriteLine($"Processing Credit Card payment for {order.Amount}");
        }
        else if (paymentType == "PayPal")
        {
            Console.WriteLine($"Processing PayPal payment for {order.Amount}");
        }
        else if (paymentType == "Bitcoin")
        {
            Console.WriteLine($"Processing Bitcoin payment for {order.Amount}");
        }
        // ❌ Every time we add a new payment type (Stripe, ApplePay),
        // we must MODIFY this class → violates OCP
    }
}
```
Problem:

Adding StripePayment means we must edit PaymentProcessor.

The class keeps growing and becomes harder to maintain.

## 🔴 Breaking LSP Example
High chance of introducing bugs while modifying.
```csharp
public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}
```
Now, imagine we create a GiftCardPayment class but force it to implement ProcessPayment, even though gift cards don’t work like normal payments:
```csharp
public class GiftCardPayment : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        // ❌ GiftCard can’t really process payments like CreditCard/PayPal
        // So we throw an exception
        throw new NotSupportedException("GiftCard cannot process payment directly.");
    }
}

public void Checkout(Order order)
{
    _paymentProcessor.ProcessPayment(order); // ❌ Will crash if GiftCardPayment is used
}
```
Why this breaks LSP?

LSP rule: Subclasses (or implementations) must be usable anywhere the base type is expected.

Here, if we substitute GiftCardPayment for IPaymentProcessor, it throws an exception instead of behaving properly.

Client code (CheckoutService) now has to know special cases → violates LSP.

✅ Fixing LSP

Instead of forcing GiftCardPayment into the wrong interface, we restructure abstractions:
```csharp
public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}

public interface IGiftCardRedemption
{
    void RedeemGiftCard(Order order);
}

public class CreditCardPayment : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine($"Processing Credit Card payment for {order.Amount}");
    }
}

public class PayPalPayment : IPaymentProcessor
{
    public void ProcessPayment(Order order)
    {
        Console.WriteLine($"Processing PayPal payment for {order.Amount}");
    }
}

public class GiftCardRedemption : IGiftCardRedemption
{
    public void RedeemGiftCard(Order order)
    {
        Console.WriteLine($"Redeeming gift card for {order.Amount}");
    }
}
```







