namespace WebApplication1.GraphQL.Types;

public class Product
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public double Price { get; set; }
    public string Category { get; set; } = default!;
    public bool InStock { get; set; }
}
