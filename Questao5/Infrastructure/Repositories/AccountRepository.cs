using Dapper;

namespace Questao5.Infrastructure.Repositories
{
    //public class AccountRepository : IAccountRepository
    //{
    //    private readonly DbSession _db;

    //    public AccountRepository(DbSession db)
    //    {
    //        _db = db;
    //    }

    //    public Account GetAccountByNumber(int accountNumber)
    //    {
    //        using var con = _db.Connection;            
    //        const string sql = "SELECT idcontacorrente as Id, numero as Number, nome as Name, ativo as Active FROM contacorrente WHERE numero = @number";
    //        return con.QueryFirstOrDefault<Account>(sql, param: new { number = accountNumber });
    //    }
    //}
}
