using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Extensions;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Application.Handlers
{
    public class FindSaldoContaHandler : IRequestHandler<SaldoContaRequest, SaldoContaResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public FindSaldoContaHandler(IMediator mediator, IMovimentacaoRepository movimentacaoRepository)
        {
            _mediator = mediator;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<SaldoContaResponse> Handle(SaldoContaRequest request, CancellationToken cancellationToken)
        {
            var conta = await _mediator.Send(new FindContaRequest { Numero = request.Conta }) 
                                ?? throw new ArgumentException(string.Format("{0}-{1}", TipoErro.INVALID_ACCOUNT.ToString(), TipoErro.INVALID_ACCOUNT.GetDescription()));

            if (!conta.Ativo)
                throw new ArgumentException(string.Format("{0}-{1}", TipoErro.INACTIVE_ACCOUNT.ToString(), TipoErro.INACTIVE_ACCOUNT.GetDescription()));

            var saldo = _movimentacaoRepository.Get(conta.Id);

            return new SaldoContaResponse
            {
                Conta = conta.Numero,
                Titular = conta.Titular,
                Data = DateTime.Now,
                Valor = saldo
            };
        }
    }
}
