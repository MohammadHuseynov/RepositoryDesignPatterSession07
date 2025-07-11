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

       

        public async Task<List<Product>> Select()
      {
          using (_context)
          {
              try
              {

                  var products = await _context.Product.ToListAsync();
                  return products;
              }
              catch (Exception)
              {

                  throw;
              }
              finally
              {
                  if (_context.Product != null) _context.Dispose();
              }
          }
      }

      
    }
}
