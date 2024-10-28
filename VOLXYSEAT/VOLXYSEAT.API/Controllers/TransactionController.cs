﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VOLXYSEAT.API.Application.Commands.Transaction.Create;
using VOLXYSEAT.API.Application.Queries.Transaction.GetByUserId;

namespace VOLXYSEAT.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;
    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByClientId(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query);

        return result != null ? Ok(result) : NotFound();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTransactionCommand request)
    {
        var result = await _mediator.Send(request);

        if (result == null)
            return BadRequest();

        return Ok(result);
    }
}
