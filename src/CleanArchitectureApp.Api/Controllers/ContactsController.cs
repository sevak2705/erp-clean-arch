using CleanArchitectureApp.Application.Features.Contact;
using CleanArchitectureApp.Application.Features.Contact.Commands;
using CleanArchitectureApp.Application.Features.Contact.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IMediator _mediator;

        public ContactsController(ILogger<ContactsController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpGet("customer")]
        public async Task<List<CustomerContactDto>> Get()
        {
            var req = await _mediator.Send(new GetCustomerContactQuery());
            return req;
        }

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<CustomerContactDto>> GetCustomerContactById(int id)
        {
            var req = await _mediator.Send(new GetCustomerContactByIdQuery(id));
            return Ok(req);
        }

        [HttpPost("customer")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerContactCommand command)
        {
            await _mediator.Send(command);
            // Handler returns Unit, so we simply return 204 No Content
            return NoContent();
        }

        [HttpPut("customer/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateCustomerContactCommand command
        )
        {
            // Ensure the route-id matches the payload
            if (id != command.Id)
                return BadRequest("Route id and command id must match.");

            await _mediator.Send(command);
            // Handler returns Unit, so we simply return 204 No Content
            return NoContent();
        }
    }
}
