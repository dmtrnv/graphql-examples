using WebApplication1.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();        // Serves /graphql endpoint and Banana Cake Pop UI at /graphql

app.MapGet("/", () => Results.Redirect("/graphql"));  // Root welcome → redirect to the UI.

app.Run();
