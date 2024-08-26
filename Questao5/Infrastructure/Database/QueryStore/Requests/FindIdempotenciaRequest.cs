
using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class FindIdempotenciaRequest : IRequest<FindIdempotenciaResponse>
    {
        public string Id { get; set; }
    }
}
