using MediatR;
using Microsoft.OpenApi.Validations;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Extensions;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Application.Handlers
{
    public class CreateMovimentacaoHandler : IRequestHandler<CreateMovimentacaoRequest, CreateMovimentacaoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IIdempotenciaRepository _idempotenciaRepository;

        public CreateMovimentacaoHandler(IMediator mediator, IMovimentacaoRepository movimentacaoRepository, IIdempotenciaRepository idempotenciaRepository)
        {
            _mediator = mediator;
            _movimentacaoRepository = movimentacaoRepository;
            _idempotenciaRepository = idempotenciaRepository;
        }

        public async Task<CreateMovimentacaoResponse> Handle(CreateMovimentacaoRequest request, CancellationToken cancellationToken)
        {
            var idempotencia = await _mediator.Send(new FindIdempotenciaRequest { Id = request.IdRequisicao });

            if (!string.IsNullOrEmpty(idempotencia.Result))
                return new CreateMovimentacaoResponse { Id = idempotencia.Result };

            var conta = await _mediator.Send(new FindContaRequest { Numero = request.Conta });

            if (string.IsNullOrEmpty(conta.Id))
                throw new ArgumentException(string.Format("{0}-{1}", TipoErro.INVALID_ACCOUNT.ToString(), TipoErro.INVALID_ACCOUNT.GetDescription()));

            if (!conta.Ativo)
                throw new ArgumentException(string.Format("{0}-{1}", TipoErro.INACTIVE_ACCOUNT.ToString(), TipoErro.INACTIVE_ACCOUNT.GetDescription()));

            if (request.Valor <= 0)
                throw new ArgumentException(string.Format("{0}-{1}", TipoErro.INVALID_VALUE.ToString(), TipoErro.INVALID_VALUE.GetDescription()));

            if (!request.Tipo.Equals("C") && !request.Tipo.Equals("D"))
                throw new ArgumentException(string.Format("{0}-{1}", TipoErro.INVALID_TYPE.ToString(), TipoErro.INVALID_TYPE.GetDescription()));

            var movimento = new Movimentacao { IdConta = conta.Id, Data = DateTime.Now, Tipo = request.Tipo, Valor = request.Valor };
            _movimentacaoRepository.Create(movimento);

            _idempotenciaRepository.Create(new Idempotencia { IdRequisicao = request.IdRequisicao, Result = movimento.Id });

            var result = new CreateMovimentacaoResponse
            {
                Id = movimento.Id
            };
            return await Task.FromResult(result);
        }
    }
}
