using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentacaoRepository
    {
        void Create(Movimentacao movimentacao);

        double GetAccountBalanceById(string id);
    }
}
