using Dapper;
using Questao5.Domain.Entities;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly DbSession _db;

        public ContaRepository(DbSession db)
        {
            _db = db;
        }

        public Conta Get(int numero)
        {
            using var con = _db.Connection;
            const string sql = "SELECT idcontacorrente as Id, numero as Numero, nome as Nome, ativo FROM contacorrente WHERE numero = @number";
            return con.QueryFirstOrDefault<Conta>(sql, param: new { number = numero });
        }
    }
}
