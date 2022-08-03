using Catalog.WebApi.Data;
using Catalog.WebApi.Entities;
using MongoDB.Driver;

namespace Catalog.WebApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext catalogContext;

    public ProductRepository(ICatalogContext catalogContext)
    {
        this.catalogContext = catalogContext;
    }

    public async Task<ICollection<Product>> Get()
    {
        return await catalogContext.Products.Find(x => true).ToListAsync();
    }

    public async Task<Product> Get(string id)
    {
        return await catalogContext.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ICollection<Product>> GetByName(string name)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Name, name);

        return await catalogContext.Products.Find(filter).ToListAsync();
    }

    public async Task<ICollection<Product>> GetByCategory(string category)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Category, category);

        return await catalogContext.Products.Find(filter).ToListAsync();
    }

    public async Task Add(Product product)
    {
        await catalogContext.Products.InsertOneAsync(product);
    }

    public async Task Update(Product product)
    {
        await catalogContext.Products.ReplaceOneAsync(filter: x => x.Id == product.Id, replacement: product);
    }

    public async Task Delete(string id)
    {
        var filter = Builders<Product>.Filter.Eq(x => x.Id, id);

        await catalogContext.Products.DeleteOneAsync(filter);
    }
}