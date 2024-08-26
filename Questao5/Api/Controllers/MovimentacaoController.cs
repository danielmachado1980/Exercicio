using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Api.Models;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;

namespace Questao5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateMovimentacaoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public Task<CreateMovimentacaoResponse> Create([FromServices] IMediator mediator,
                                                       [FromBody] CreateMovimentacaoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        [ProducesResponseType(typeof(SaldoContaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Route("saldo/{conta}")]
        public Task<SaldoContaResponse> Balance([FromServices] IMediator mediator, 
                                                [FromRoute] int conta)
        {
            return mediator.Send(new SaldoContaRequest { Conta = conta });
        }
    }
}
