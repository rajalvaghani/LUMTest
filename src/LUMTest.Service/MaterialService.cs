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

        public Task<Material> Get(string id)
        {
            return _materialRepository.GetById(id);
        }
        public async Task<Material> Insert(Material material)
        {
            return await _materialRepository.Insert(material);
        }

        public async Task<Material> Update(Material material)
        {
            return await _materialRepository.Update(material);
        }

        public async Task<bool> ElementExists(string id)
        {
            return await _materialRepository.ElementExists(id);
        }

        public async Task<bool> Delete(string id)
        {
            return await _materialRepository.Delete(id);
        }
    }
}
