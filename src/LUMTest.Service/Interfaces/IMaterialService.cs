using System.Collections.Generic;
using System.Threading.Tasks;
using LUMTest.Domain;

namespace LUMTest.Service.Interfaces
{
    public interface IMaterialService
    {
        Task<IEnumerable<Material>> GetAll();
        
    }
}
