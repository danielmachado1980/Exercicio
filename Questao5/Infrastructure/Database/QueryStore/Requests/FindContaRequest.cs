using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class FindContaRequest : IRequest<FindContaResponse>
    {
        public int Numero { get; set; }
    }
}
