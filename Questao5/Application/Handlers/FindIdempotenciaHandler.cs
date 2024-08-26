using MediatR;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Application.Handlers
{
    public class FindIdempotenciaHandler : IRequestHandler<FindIdempotenciaRequest, FindIdempotenciaResponse>
    {
        private readonly IIdempotenciaRepository _idempotenciaRepository;

        public FindIdempotenciaHandler(IIdempotenciaRepository idempotenciaRepository)
        {
            _idempotenciaRepository = idempotenciaRepository;
        }
        public Task<FindIdempotenciaResponse> Handle(FindIdempotenciaRequest request, CancellationToken cancellationToken)
        {
            var idempontencia = _idempotenciaRepository.GetByRequestId(request.Id);

            var response = new FindIdempotenciaResponse
            {
                Result = idempontencia?.Result
            };

            return Task.FromResult(response);
        }
    }
}
