namespace WebApplication1.Models;

public class Order
{
    public string Id { get; set; } = default!;
    public string CustomerId { get; set; } = default!;
    public double TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public string CreatedAt { get; set; } = default!;
}
