using WebApplication1.GraphQL.Enums;
using WebApplication1.GraphQL.Inputs;
using WebApplication1.GraphQL.Types;

namespace WebApplication1.GraphQL;

public class Query
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = "p-1", Name = "Aurora Headphones",    Price = 199.99, Category = "Electronics", InStock = true  },
        new Product { Id = "p-2", Name = "Nimbus Smartwatch",    Price = 249.00, Category = "Electronics", InStock = true  },
        new Product { Id = "p-3", Name = "Solstice Desk Lamp",   Price =  49.50, Category = "Home",        InStock = false },
        new Product { Id = "p-4", Name = "Cascade Water Bottle", Price =  19.95, Category = "Outdoors",    InStock = true  },
        new Product { Id = "p-5", Name = "Verdant Plant Pot",    Price =  14.00, Category = "Home",        InStock = true  }
    };

    private static readonly List<Order> Orders = new()
    {
        new Order { Id = "o-1", CustomerId = "c-1", TotalAmount = 219.94, Status = OrderStatus.DELIVERED, CreatedAt = "2025-09-15T10:21:00Z" },
        new Order { Id = "o-2", CustomerId = "c-1", TotalAmount =  49.50, Status = OrderStatus.SHIPPED,   CreatedAt = "2025-10-02T14:05:00Z" },
        new Order { Id = "o-3", CustomerId = "c-2", TotalAmount = 249.00, Status = OrderStatus.PENDING,   CreatedAt = "2025-10-09T09:00:00Z" },
        new Order { Id = "o-4", CustomerId = "c-2", TotalAmount =  33.95, Status = OrderStatus.CANCELLED, CreatedAt = "2025-10-12T18:42:00Z" },
        new Order { Id = "o-5", CustomerId = "c-3", TotalAmount = 199.99, Status = OrderStatus.SHIPPED,   CreatedAt = "2025-10-20T08:15:00Z" }
    };

    public IEnumerable<Product> GetFeaturedProducts()
        => Products.Where(p => p.InStock);

    public Product? GetProductById(ProductByIdInput input)
        => Products.FirstOrDefault(p => p.Id == input.ProductId);

    public IEnumerable<Order> SearchOrders(OrderSearchInput input)
    {
        IQueryable<Order> query = Orders.AsQueryable();

        query = query.Where(o => o.CustomerId == input.CustomerId);

        if (input.Status.HasValue)
            query = query.Where(o => o.Status == input.Status.Value);

        var results = query.ToList();

        if (input.Limit.HasValue && input.Limit.Value > 0)
            results = results.Take(input.Limit.Value).ToList();

        return results;
    }
}
