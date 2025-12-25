using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonInfoSystems.Services;

public interface ICRUDService<T> where T : class
{
    Task<T> Add(T entity);
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task Update(T entity);
    Task<bool> DeleteById(int id);
}
