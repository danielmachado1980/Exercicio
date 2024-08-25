using Dapper;

using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly DbSession _db;
        public MovimentacaoRepository(DbSession db) {

            _db = db;
        }

        public void Create(Moviment moviment)
        {
            using var connection = _db.Connection;                           
            connection.Open();
            moviment.Id = Guid.NewGuid().ToString();
            using (var transaction = connection.BeginTransaction())
            {
                
                var sSQLCommand = "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) " +
                                "VALUES (@Id, @IdCheckingAccount, @Date, @MovimentType, @Value)";
                connection.Execute(sSQLCommand, moviment);
                transaction.Commit();
            }            
        }

        public double GetAccountBalanceById(string id)
        {
            using var connection = _db.Connection;
           
            var sSQLCommand = "SELECT COALESCE(SUM(CASE WHEN tipomovimento = 'D' THEN  " +
                                "-1*valor " +
                                "ELSE valor "+
                                "END),0) AS saldo " +
                                "FROM movimento " +
                                "WHERE idcontacorrente = @idContaCorrente";
            return connection.QuerySingleOrDefault<double>(sSQLCommand, param: new { idContaCorrente = id });
           
        }
    }
}
