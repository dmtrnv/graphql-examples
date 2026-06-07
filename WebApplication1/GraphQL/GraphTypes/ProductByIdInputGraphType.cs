using GraphQL.Types;
using WebApplication1.GraphQL.Inputs;

namespace WebApplication1.GraphQL.GraphTypes;

public class ProductByIdInputGraphType : InputObjectGraphType<ProductByIdInput>
{
    public ProductByIdInputGraphType()
    {
        Name = "ProductByIdInput";
        Description = "Input for fetching a product by id.";

        Field(x => x.ProductId, type: typeof(NonNullGraphType<IdGraphType>)).Description("The product identifier.");
    }
}
