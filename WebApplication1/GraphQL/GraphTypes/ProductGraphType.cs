using GraphQL.Types;
using WebApplication1.GraphQL.Types;

namespace WebApplication1.GraphQL.GraphTypes;

public class ProductGraphType : ObjectGraphType<Product>
{
    public ProductGraphType()
    {
        Name = "Product";
        Description = "A purchasable product.";

        Field(x => x.Id,       type: typeof(NonNullGraphType<IdGraphType>)).Description("Unique product identifier.");
        Field(x => x.Name,     type: typeof(NonNullGraphType<StringGraphType>)).Description("Display name of the product.");
        Field(x => x.Price,    type: typeof(NonNullGraphType<FloatGraphType>)).Description("Unit price.");
        Field(x => x.Category, type: typeof(NonNullGraphType<StringGraphType>)).Description("Product category.");
        Field(x => x.InStock,  type: typeof(NonNullGraphType<BooleanGraphType>)).Description("Whether the product is currently in stock.");
    }
}
