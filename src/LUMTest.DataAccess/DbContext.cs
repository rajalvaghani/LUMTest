using LUMTest.DataAccess.Interfaces;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Exceptions.Database;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace LUMTest.DataAccess
{
    public class DbContext : IDbContext
    {
        private readonly DocumentStore _localStore;
        public IDocumentStore store => _localStore;
        private readonly DatabaseSettings _databaseSettings;

        public DbContext(IOptionsMonitor<DatabaseSettings> settings)
        {
            _databaseSettings = settings.CurrentValue;

            _localStore = new DocumentStore()
            {
                Database = _databaseSettings.DatabaseName,
                Urls = _databaseSettings.Urls
            };

            _localStore.Initialize();

            EnsureDatabaseIsCreated();
        }

        public void EnsureDatabaseIsCreated()
        {

            try
            {
                _localStore.Maintenance.ForDatabase(_databaseSettings.DatabaseName).Send(new GetStatisticsOperation());
            }
            catch (DatabaseDoesNotExistException)
            {

                _localStore.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(_databaseSettings.DatabaseName)));

            }

        }

    }
}
