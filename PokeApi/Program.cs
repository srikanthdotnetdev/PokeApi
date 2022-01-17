using MediatR;
using PokeApi;
using PokeApi.DDD;
using PokeApi.GraphQL;
using PokeApi.Repository;

using Path = System.IO.Path;
using ReadPokeMon = PokeApi.DDD.ReadPokeMon;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<GraphQlQueries.Query>();
     


builder.Services.AddMediatR(typeof(PokeMon).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.Run();

