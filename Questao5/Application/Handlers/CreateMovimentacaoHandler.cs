using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Infrastructure.Database.Handler
{
    public class CreateMovimentacaoHandler : IRequestHandler<CreateMovimentacaoRequest, CreateMovimentacaoResponse>
    {
        private readonly IMovimentacaoRepository _movimentRepository;
        private readonly IIdempotenciaRepository _idempontencyRepository;

        public CreateMovimentacaoHandler(IMovimentacaoRepository movimentacaoRepository,
                                         IIdempotenciaRepository idempotenciaRepository)
        {
            _movimentRepository = movimentacaoRepository;
            _idempontencyRepository = idempotenciaRepository;
        }

        public Task<CreateMovimentacaoResponse> Handle(CreateMovimentacaoRequest request, CancellationToken cancellationToken)
        {
            var movimentacao = new Movimentacao
            {
                IdConta = request.Conta,
                Data = DateTime.Now,
                Tipo = request.Tipo,
                Valor = request.Valor
            };

            _movimentRepository.Create(movimentacao);

            var idempotencia = new Idempotencia
            {
                RequestId = request.IdRequisicao,
                Result = movimentacao.Id
            };

            _idempontencyRepository.Create(idempotencia);

            var result = new CreateMovimentacaoResponse
            {
                Id = movimentacao.Id
            };
            return Task.FromResult(result);
        }
    }
}
