using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApiCopyPastUtils.CopyPastUtils.SqlConnectionFactory
{
    public interface ISqlConnectionFactory : IDisposable, IAsyncDisposable
    {
        ValueTask<IDbConnection> StartQuery();
    }
    class SqlConnectionFactory(IConfiguration configuration) : IDisposable, IAsyncDisposable, ISqlConnectionFactory
    {
        private DbConnection _connection = null!;
        private bool _disposedValue;
        private bool disposedValue;

        public async ValueTask<IDbConnection> StartQuery()
        {
            if (_connection is not null)
                return _connection;

            var connectionString = configuration.GetConnectionString("mssql");
            _connection = new SqlConnection(connectionString);
            await _connection.OpenAsync();
            return _connection;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection?.Dispose();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SqlConnectionFactory()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (!disposedValue)
            {
                if (_connection is not null)
                    await _connection.DisposeAsync();
            }
        }
    }
}
