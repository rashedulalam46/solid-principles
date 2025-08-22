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


