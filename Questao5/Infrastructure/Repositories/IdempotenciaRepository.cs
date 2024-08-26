using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        private readonly DbSession _db;

        public IdempotenciaRepository(DbSession db)
        {
            _db = db;
        }       
        public void Create(Idempotencia idempotencia)
        {
            using var connection = _db.Connection;
            Guid id = Guid.NewGuid();
            connection.Open();
            idempotencia.Id = id.ToString();
            using (var transaction = connection.BeginTransaction()){
                var sSQLCommand = "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) " +
                                    "VALUES (@Id, @IdRequisicao, @Result)";
                connection.Execute(sSQLCommand, idempotencia);
                transaction.Commit();
            }
        }

        public Idempotencia GetByRequestId(string requestId)
        {
            using var connection = _db.Connection;

            const string sql = "SELECT chave_idempotencia as Id, " +
                                      "requisicao as IdRequisicao, " +
                                      "resultado as Result " +
                               "FROM idempotencia " +
                               "WHERE requisicao = @RequestId";
            return connection.QueryFirstOrDefault<Idempotencia>(sql, param: new { RequestId = requestId });            
        }
    }
}
