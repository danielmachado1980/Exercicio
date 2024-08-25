using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentacaoService
    {
        Task<string> Create(Movimentacao movimentacaoRequest);

        //Task<AccountBalanceResponse> GetAccountBalanceAsync(int accountNumber);
    }
}
