using System.Collections.Generic;
using System.Threading.Tasks;
using LUMTest.DataAccess.Interfaces;
using LUMTest.Domain;
using LUMTest.Service.Interfaces;

namespace LUMTest.Service
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            return await _materialRepository.GetAll();
        }

    }
}
