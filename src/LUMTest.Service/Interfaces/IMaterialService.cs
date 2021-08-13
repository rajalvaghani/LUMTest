using System.Collections.Generic;
using System.Threading.Tasks;
using LUMTest.Domain;

namespace LUMTest.Service.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAll();
        Task<Material> Get(string id);
        Task<Material> Insert(Material material);
        Task<Material> Update(Material material);
        Task<bool> ElementExists(string id);
    }
}
