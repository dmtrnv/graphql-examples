using WebApplication1.Models;

namespace WebApplication1.GraphQL;

public class Query
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = "1", Name = "Laptop",         Price = 1299.99, Category = "Electronics", InStock = true  },
        new Product { Id = "2", Name = "Wireless Mouse", Price = 29.99,   Category = "Electronics", InStock = true  },
        new Product { Id = "3", Name = "Coffee Mug",     Price = 12.50,   Category = "Kitchen",     InStock = false },
        new Product { Id = "4", Name = "Notebook",       Price = 4.99,    Category = "Stationery",  InStock = true  },
        new Product { Id = "5", Name = "Desk Chair",     Price = 249.00,  Category = "Furniture",   InStock = true  }
    };

    private static readonly List<Order> Orders = new()
    {
        new Order { Id = "1001", CustomerId = "C-1", TotalAmount = 1329.98, Status = OrderStatus.SHIPPED,   CreatedAt = "2025-01-15T10:30:00Z" },
        new Order { Id = "1002", CustomerId = "C-1", TotalAmount = 12.50,   Status = OrderStatus.DELIVERED, CreatedAt = "2025-02-02T14:05:00Z" },
        new Order { Id = "1003", CustomerId = "C-2", TotalAmount = 249.00,  Status = OrderStatus.PENDING,   CreatedAt = "2025-02-20T09:15:00Z" },
        new Order { Id = "1004", CustomerId = "C-2", TotalAmount = 4.99,    Status = OrderStatus.CANCELLED, CreatedAt = "2025-03-01T16:45:00Z" },
        new Order { Id = "1005", CustomerId = "C-3", TotalAmount = 29.99,   Status = OrderStatus.SHIPPED,   CreatedAt = "2025-03-12T11:00:00Z" }
    };

    public IEnumerable<Product> GetFeaturedProducts() => Products;

    public Product? GetProductById(ProductByIdInput input) =>
        Products.FirstOrDefault(p => p.Id == input.ProductId);

    public IEnumerable<Order> SearchOrders(OrderSearchInput input)
    {
        IEnumerable<Order> query = Orders.Where(o => o.CustomerId == input.CustomerId);

        if (input.Status is { } status)
        {
            query = query.Where(o => o.Status == status);
        }

        if (input.Limit is { } limit)
        {
            query = query.Take(limit);
        }

        return query;
    }
}
