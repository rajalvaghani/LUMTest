using LUMTest.DataAccess.Interfaces;
using LUMTest.Domain;

namespace LUMTest.DataAccess
{
    public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {        public MaterialRepository(IDbContext context) : base(context)
        {
        }
    }
}
