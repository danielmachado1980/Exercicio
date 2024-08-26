using Microsoft.Data.Sqlite;
using System.Data;

namespace Questao5.Infrastructure.Sqlite
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqliteConnection(configuration
                     .GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
