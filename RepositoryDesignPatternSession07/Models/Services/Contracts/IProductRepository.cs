using RepositoryDesignPatternSession07.Models.DomainModels.ProductAggregates;
using RepositoryDesignPatternSession07.Models.Services.Contracts.RepositoryFrameworks;

namespace RepositoryDesignPatternSession07.Models.Services.Contracts
{
    public interface IProductRepository 
    {

        Task<List<Product>> Select();
        //Person SelectById(Guid Id);
        //void Insert(Person person);
        //void Update(Person person);
        //void Delete(Guid Id);
    }

}
