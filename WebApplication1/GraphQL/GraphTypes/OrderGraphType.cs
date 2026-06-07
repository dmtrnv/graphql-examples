using GraphQL.Types;
using WebApplication1.GraphQL.Types;

namespace WebApplication1.GraphQL.GraphTypes;

public class OrderGraphType : ObjectGraphType<Order>
{
    public OrderGraphType()
    {
        Name = "Order";
        Description = "A customer order.";

        Field(x => x.Id,          type: typeof(NonNullGraphType<IdGraphType>)).Description("Unique order identifier.");
        Field(x => x.CustomerId,  type: typeof(NonNullGraphType<IdGraphType>)).Description("Customer who placed the order.");
        Field(x => x.TotalAmount, type: typeof(NonNullGraphType<FloatGraphType>)).Description("Total amount for the order.");
        Field(x => x.Status,      type: typeof(NonNullGraphType<OrderStatusGraphType>)).Description("Order status.");
        Field(x => x.CreatedAt,   type: typeof(NonNullGraphType<StringGraphType>)).Description("Order creation timestamp (ISO 8601).");
    }
}
