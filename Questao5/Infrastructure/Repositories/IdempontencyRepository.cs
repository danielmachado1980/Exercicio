using Dapper;
using Questao5.Domain.Entities.Account;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories
{
    public class IdempontenciaRepository : IIdempontenciaRepository
    {
        private readonly DbSession _db;

        public IdempontencyRepositoria(DbSession db)
        {
            _db = db;
        }       
        public void Create(Idempontency idempontency)
        {
            using var connection = _db.Connection;
            Guid id = Guid.NewGuid();
            connection.Open();
            idempontency.Id = id.ToString();
            using (var transaction = connection.BeginTransaction()){
                var sSQLCommand = "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) " +
                                "VALUES (@Id, @RequestId, @Result)";
                connection.Execute(sSQLCommand, idempontency);
                transaction.Commit();
            }
        }

        public Idempontency GetByRequestId(string requestId)
        {
            using var connection = _db.Connection;

            const string sql = "SELECT chave_idempotencia as Id, " +
                                      "requisicao as RequestId, " +
                                      "resultado as Result " +
                               "FROM idempotencia " +
                               "WHERE requisicao = @RequestId";
            return connection.QueryFirstOrDefault<Idempontency>(sql, param: new { RequestId = requestId });            
        }
    }
}
