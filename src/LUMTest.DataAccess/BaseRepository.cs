using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LUMTest.DataAccess.Interfaces;
using Raven.Client.Documents;

namespace LUMTest.DataAccess
{
    public class BaseRepository<T> : IRepository<T>
    {
        private readonly IDbContext _context;

        public BaseRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<T>> GetAll()
        {
            try
            {
                using var session = _context.store.OpenAsyncSession();
                var elements = await session.Query<T>(collectionName: "Materials").ToListAsync();
                return elements;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

    }

    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
