using RepositoryDesignPatternSession07.Models.DomainModels.ProductAggregates;
using RepositoryDesignPatternSession07.Models.Services.Contracts.RepositoryFrameworks;

namespace RepositoryDesignPatternSession07.Models.Services.Contracts
{
        // It now inherits all the methods from IRepository for the 'Product' entity
        public interface IProductRepository : IRepository<Product>
        {
            // You only add methods here that are SPECIFIC to products.
            // For example:
            // List<Product> GetProductsByCategory(int categoryId);
            // Product GetProductByName(string name);
        }
        
}
