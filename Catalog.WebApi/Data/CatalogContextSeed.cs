using Catalog.WebApi.Entities;
using MongoDB.Driver;

namespace Catalog.WebApi.Data;

public class CatalogContextSeed
{
    public void SeedData(IMongoCollection<Product> products)
    {
    }
}