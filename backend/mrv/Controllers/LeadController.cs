using MediatR;
using Microsoft.AspNetCore.Mvc;
using mrv.Features.Commands;
using mrv.Features.Queries;
using mrv.Models;

namespace mrv.Controllers
{
    [Route("api/lead")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private IMediator _mediator;

        public LeadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLeadCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllLeadsQuery()));
        }
        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            return Ok(await _mediator.Send(new GetNewLeadsQuery()));
        }
        [HttpGet("approved")]
        public async Task<IActionResult> GetApproved()
        {
            return Ok(await _mediator.Send(new GetApprovedLeadsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetLeadByIdQuery { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteLeadCommand { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateLeadCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("evaluate/{id}")]
        public async Task<IActionResult> Evaluate(int id, EvaluateLeadCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }
    }
}
