using Application.Features.BlackLists.Commands.Create;
using Application.Features.BlackLists.Commands.Delete;
using Application.Features.BlackLists.Commands.Update;
using Application.Features.BlackLists.Queries.GetById;
using Application.Features.BlackLists.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlackListsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBlackListCommand createBlackListCommand)
    {
        CreatedBlackListResponse response = await Mediator.Send(createBlackListCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBlackListCommand updateBlackListCommand)
    {
        UpdatedBlackListResponse response = await Mediator.Send(updateBlackListCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBlackListResponse response = await Mediator.Send(new DeleteBlackListCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBlackListResponse response = await Mediator.Send(new GetByIdBlackListQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlackListQuery getListBlackListQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBlackListListItemDto> response = await Mediator.Send(getListBlackListQuery);
        return Ok(response);
    }
}