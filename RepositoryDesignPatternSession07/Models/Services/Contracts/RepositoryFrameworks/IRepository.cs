namespace RepositoryDesignPatternSession07.Models.Services.Contracts.RepositoryFrameworks
{
    public interface IRepository<T>
    {
        IEnumerable<T> Select();
        T SelectById(Guid Id);
        void Insert(T obj);
        void Update(T obj);
        void Update(Guid Id, string values);
        void Delete(object? Id);
        void Delete(T obj);
        void Save();
    }
}
