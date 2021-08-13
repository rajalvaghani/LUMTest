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

        public async Task<T> GetById(string id)
        {
            try
            {
                using var session = _context.store.OpenAsyncSession();
                var element = await session.LoadAsync<T>(id);

                return element;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

        public async Task<T> Insert(T entity)
        {
            try
            {
                using var session = _context.store.OpenAsyncSession();
                Guid ID = Guid.NewGuid();
                await session.StoreAsync(entity, ID.ToString());
                await session.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                using var session = _context.store.OpenAsyncSession();
                //var element = await session.LoadAsync<T>("test");
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> ElementExists(string id)
        {
            try
            {
                using var session = _context.store.OpenAsyncSession();
                var element = await session.Advanced.ExistsAsync(id);
                return element;
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
