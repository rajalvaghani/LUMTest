using Raven.Client.Documents;

namespace LUMTest.DataAccess.Interfaces
{
    public interface IDbContext
    {
        public IDocumentStore store { get; }
    }
}
