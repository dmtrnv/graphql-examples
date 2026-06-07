using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.SystemTextJson;
using WebApplication1.GraphQL;
using WebApplication1.GraphQL.GraphTypes;

var builder = WebApplication.CreateBuilder(args);

// Register the hardcoded data source as a singleton.
builder.Services.AddSingleton<Query>();

// Register GraphQL.NET services.
builder.Services
    .AddSingleton<RootQuery>()
    .AddSingleton<OrderStatusGraphType>()
    .AddSingleton<ProductGraphType>()
    .AddSingleton<OrderGraphType>()
    .AddSingleton<ProductByIdInputGraphType>()
    .AddSingleton<OrderSearchInputGraphType>()
    .AddSingleton<AppSchema>()
    .AddGraphQL(b => b
        .AddSystemTextJson());

var app = builder.Build();

// GraphQL HTTP endpoint (GET + POST + OPTIONS).
app.UseGraphQL<AppSchema>("/graphql");

// In-browser GraphQL Playground for executing and exploring queries.
app.UseGraphQLPlayground(
    "/ui",
    new PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql"
    });

// Root welcome → redirect to the UI.
app.MapGet("/", () => Results.Redirect("/ui"));

app.Run();
