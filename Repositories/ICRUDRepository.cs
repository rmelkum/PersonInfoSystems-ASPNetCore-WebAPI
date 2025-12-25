namespace PersonInfoSystems.Repositories;

public interface ICRUDRepository<T> where T : class
{
    Task<T> Add(T entity);
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task Update(T entity);
    Task<bool> DeleteById(int id);
}