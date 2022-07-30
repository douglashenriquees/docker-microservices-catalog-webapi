using Catalog.WebApi.Entities;
using MongoDB.Driver;

namespace Catalog.WebApi.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}