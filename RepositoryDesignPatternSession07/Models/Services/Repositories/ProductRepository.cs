using Microsoft.EntityFrameworkCore;
using RepositoryDesignPatternSession07.Models.DomainModels.ProductAggregates;
using RepositoryDesignPatternSession07.Models.Services.Contracts;
using RepositoryDesignPatternSession07.Models.Services.Contracts.RepositoryFrameworks;

namespace RepositoryDesignPatternSession07.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
      private readonly RepositoryDesignPatternSession07DbContext _context;

      public ProductRepository(RepositoryDesignPatternSession07DbContext context)
      {
          _context = context;
      }

      public void Add(Product product)
      {
          _context.Product.Add(product);
      }

      public void Delete(Product product)
      {
          _context.Product.Remove(product);
      }

      public List<Product> GetAll()
      {
          return _context.Product.ToList();
      }

      public Product GetById(object id)
      {
          return _context.Product.Find(id);
      }

      public void Update(Product product)
      {
          _context.Product.Update(product);
      }

      public void SaveChanges()
      {
          _context.SaveChanges();
      }
    }
}
