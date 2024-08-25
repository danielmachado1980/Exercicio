using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Api.Models;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

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
            try
            {
                return mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw;//return BadRequest(ex.Message);
            }
        }
    }
}
