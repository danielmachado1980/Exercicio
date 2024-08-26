using MediatR;

namespace Questao5.Application.Commands.Requests
{
    public class CreateIdempotenciaRequest : IRequest<string>
    {        
        public string IdRequisicao { get; set; }
        public string Result { get; set; }
    }        
}
