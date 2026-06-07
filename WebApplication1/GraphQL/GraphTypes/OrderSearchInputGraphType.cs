using GraphQL.Types;
using WebApplication1.GraphQL.Inputs;

namespace WebApplication1.GraphQL.GraphTypes;

public class OrderSearchInputGraphType : InputObjectGraphType<OrderSearchInput>
{
    public OrderSearchInputGraphType()
    {
        Name = "OrderSearchInput";
        Description = "Input for searching orders.";

        Field(x => x.CustomerId, type: typeof(NonNullGraphType<IdGraphType>)).Description("The customer identifier to search for.");
        Field(x => x.Status,     type: typeof(OrderStatusGraphType)).Description("Optional order status filter.");
        Field(x => x.Limit,      type: typeof(IntGraphType)).Description("Optional maximum number of orders to return.");
    }
}
