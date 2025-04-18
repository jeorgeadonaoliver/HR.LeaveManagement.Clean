using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveMangement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveAllocationController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDetailsDto>>> Get(bool isLoggedInUser = false)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationListQuery());
        return Ok(leaveAllocation);
    }

    [HttpGet("id")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQuery
        {
            Id = id
        });

        return Ok(leaveAllocation);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateLeaveAllocationCommand createLeaveAllocationCommand) {

        var response = _mediator.Send(createLeaveAllocationCommand);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateLeaveAllocationCommand updateLeaveAllocationCommand)
    {

        var response = await _mediator.Send(updateLeaveAllocationCommand);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id) {

        var command = new DeleteLeaveAllocationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

}
