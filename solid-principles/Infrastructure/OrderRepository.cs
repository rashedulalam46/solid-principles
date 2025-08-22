namespace SolidPrinciples.Infrastructure
{
    public class OrderRepository
    {
        public void Save(Domain.Order order)
        {
            Console.WriteLine($"Order {order.OrderId} saved to database.");
        }
    }
}
        
