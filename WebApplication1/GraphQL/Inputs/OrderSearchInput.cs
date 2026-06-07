using WebApplication1.GraphQL.Enums;

namespace WebApplication1.GraphQL.Inputs;

public class OrderSearchInput
{
    public string CustomerId { get; set; } = default!;
    public OrderStatus? Status { get; set; }
    public int? Limit { get; set; }
}
