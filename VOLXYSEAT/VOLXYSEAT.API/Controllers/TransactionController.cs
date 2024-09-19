using MediatR;
using Microsoft.AspNetCore.Mvc;
using VOLXYSEAT.API.Application.Commands.Transaction.Create;

namespace VOLXYSEAT.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;
    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTransactionCommand request)
    {
        var result = await _mediator.Send(request);

        if (result == null)
            return BadRequest();

        return Ok(result);
    }
}
