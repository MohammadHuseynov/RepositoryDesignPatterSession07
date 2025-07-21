using System.Collections.Generic;
namespace RepositoryDesignPatternSession07.Models.Services.Contracts.RepositoryFrameworks
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // CREATE
        void Add(TEntity entity);

        // READ
        TEntity GetById(object id);
        List<TEntity> GetAll();

        // UPDATE
        void Update(TEntity entity);

        // DELETE
        void Delete(TEntity entity);

        // PERSISTENCE
        void SaveChanges();
    }
}
