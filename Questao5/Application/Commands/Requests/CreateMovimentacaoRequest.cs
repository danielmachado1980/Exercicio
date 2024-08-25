using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class CreateMovimentacaoRequest : IRequest<CreateMovimentacaoResponse>
    {
        public string IdRequisicao { get; set; }

        public int Conta { get; set; }

        public double Valor { get; set; }

        public string Tipo { get; set; }
    }
}
