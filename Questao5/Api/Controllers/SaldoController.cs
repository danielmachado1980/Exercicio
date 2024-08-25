using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        [HttpGet]
        public Task<CreateMovimentacaoResponse> Get([FromServices] IMediator mediator,
                                                    [FromBody] CreateMovimentacaoRequest command)
        {
            return mediator.Send(command);
        }
    }
}
