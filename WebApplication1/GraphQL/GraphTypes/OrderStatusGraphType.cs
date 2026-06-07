using GraphQL.Types;
using WebApplication1.GraphQL.Enums;

namespace WebApplication1.GraphQL.GraphTypes;

public class OrderStatusGraphType : EnumerationGraphType<OrderStatus>
{
    public OrderStatusGraphType()
    {
        Name = "OrderStatus";
        Description = "Lifecycle status of an order.";
    }
}
