using HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeDetails;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveMangement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
            return leaveTypes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailQuery(id));

            return Ok(leaveType);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaveTypeCommand leaveType) 
        {
            var response = await _mediator.Send(leaveType);
            return CreatedAtAction(nameof(Get), new { id = response});
        }

        //HttpPut("{id}")]
        //[ProducesResponseType(StatusCode.Status204Content)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(StatusCode.Status404NotFound)]
        //public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveTypeCommand) { 

        //    await _mediator.Send(leaveTypeCommand);
        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCode.Status204Content)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(StatusCode.Status404NotFound)]
        //public async Task<ActionResult> Put(int id)
        //{
        //    var command = new DeleteLeaveTypeCommand { Id = id };
        //    await _mediator.Send(command);
        //    return NoContent();
        //}
    }
}
