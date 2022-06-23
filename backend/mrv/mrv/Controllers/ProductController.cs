using MediatR;
using Microsoft.AspNetCore.Mvc;
using mrv.Features.Commands;
using mrv.Features.Queries;
using mrv.Models;

namespace mrv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }
    }
}
