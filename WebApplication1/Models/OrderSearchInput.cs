namespace WebApplication1.Models;

public class OrderSearchInput
{
    public string CustomerId { get; set; } = default!;
    public OrderStatus? Status { get; set; }
    public int? Limit { get; set; }
}
