using Application.Features.ApplicationStates.Commands.Create;
using Application.Features.ApplicationStates.Commands.Delete;
using Application.Features.ApplicationStates.Commands.Update;
using Application.Features.ApplicationStates.Queries.GetById;
using Application.Features.ApplicationStates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationStatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicationStateCommand createApplicationStateCommand)
    {
        CreatedApplicationStateResponse response = await Mediator.Send(createApplicationStateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicationStateCommand updateApplicationStateCommand)
    {
        UpdatedApplicationStateResponse response = await Mediator.Send(updateApplicationStateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] short id)
    {
        DeletedApplicationStateResponse response = await Mediator.Send(new DeleteApplicationStateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] short id)
    {
        GetByIdApplicationStateResponse response = await Mediator.Send(new GetByIdApplicationStateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationStateQuery getListApplicationStateQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationStateListItemDto> response = await Mediator.Send(getListApplicationStateQuery);
        return Ok(response);
    }
}