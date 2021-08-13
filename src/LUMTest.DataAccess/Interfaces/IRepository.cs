using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUMTest.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<bool> ElementExists(string id);
        Task<bool> Delete(string id);
    }
}