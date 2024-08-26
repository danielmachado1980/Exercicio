using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class SaldoContaRequest : IRequest<SaldoContaResponse>
    {
        public int Conta { get; set; }
    }
}
