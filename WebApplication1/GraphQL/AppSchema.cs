using GraphQL.Types;
using WebApplication1.GraphQL.GraphTypes;

namespace WebApplication1.GraphQL;

public class AppSchema : Schema
{
    public AppSchema(
        IServiceProvider services,
        RootQuery query,
        OrderStatusGraphType orderStatus,
        ProductGraphType product,
        OrderGraphType order,
        ProductByIdInputGraphType productByIdInput,
        OrderSearchInputGraphType orderSearchInput) : base(services)
    {
        Query = query;
        RegisterType(orderStatus);
        RegisterType(product);
        RegisterType(order);
        RegisterType(productByIdInput);
        RegisterType(orderSearchInput);
    }
}
