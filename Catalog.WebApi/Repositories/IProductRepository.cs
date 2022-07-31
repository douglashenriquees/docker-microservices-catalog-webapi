using Catalog.WebApi.Entities;

namespace Catalog.WebApi.Repositories;

public interface IProductRepository
{
    Task<ICollection<Product>> Get();

    Task<Product> Get(string id);

    Task<ICollection<Product>> GetByName(string name);

    Task<ICollection<Product>> GetByCategory(string category);

    Task Add(Product product);

    Task Update(Product product);

    Task Delete(string id);
}