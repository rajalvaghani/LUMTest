using System.Collections.Generic;
using System.Threading.Tasks;

namespace LUMTest.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAll();
    }
}