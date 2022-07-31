using Catalog.WebApi.Data;
using Catalog.WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); x.RoutePrefix = ""; });
}

app.UseAuthorization();

app.MapControllers();

app.Run();