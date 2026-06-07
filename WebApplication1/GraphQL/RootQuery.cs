using GraphQL;
using GraphQL.Types;
using WebApplication1.GraphQL.GraphTypes;

namespace WebApplication1.GraphQL;

public class RootQuery : ObjectGraphType
{
    public RootQuery(Query query)
    {
        Name = "Query";
        Description = "Root query.";

        Field<ListGraphType<ProductGraphType>>("getFeaturedProducts")
            .Resolve(_ => query.GetFeaturedProducts())
            .Description("Returns the list of featured products.");

        Field<ProductGraphType>("getProductById")
            .Argument<NonNullGraphType<ProductByIdInputGraphType>>("input")
            .Resolve(context =>
            {
                var input = context.GetArgument<Inputs.ProductByIdInput>("input");
                return query.GetProductById(input);
            })
            .Description("Returns a single product by its identifier, or null if not found.");

        Field<ListGraphType<OrderGraphType>>("searchOrders")
            .Argument<NonNullGraphType<OrderSearchInputGraphType>>("input")
            .Resolve(context =>
            {
                var input = context.GetArgument<Inputs.OrderSearchInput>("input");
                return query.SearchOrders(input);
            })
            .Description("Searches for orders belonging to a customer, optionally filtered by status.");
    }
}
