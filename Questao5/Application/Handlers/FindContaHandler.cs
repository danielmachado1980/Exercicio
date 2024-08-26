using MediatR;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Extensions;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Application.Handlers
{
    public class FindContaHandler : IRequestHandler<FindContaRequest, FindContaResponse>
    {
        private readonly IContaRepository _contaRepository;

        public FindContaHandler(IContaRepository accountRepository)
        {
            _contaRepository = accountRepository;
        }

        public Task<FindContaResponse> Handle(FindContaRequest request, CancellationToken cancellationToken)
        {
            var conta = _contaRepository.Get(request.Numero);

            if(conta is null)
                throw new ArgumentException(string.Format("{0}-{1}", TipoErro.INVALID_ACCOUNT.ToString(), TipoErro.INVALID_ACCOUNT.GetDescription()));

            var response = new FindContaResponse
            {
                Id = conta.Id,
                Ativo = conta.Ativo,
                Titular = conta.Nome,
                Numero = conta.Numero,
            };

            return Task.FromResult(response);
        }
    }
}
