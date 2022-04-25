using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Domain.Libros.Command.CreateLibro;
using Application.Domain.Libros.Query.GetLibroById;
using Application.Domain.Libros.Query.GetLibrosPaged;
using MediatR;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetLibroById(int id)
        {
            var resp = await _mediator.Send(new GetLibroByIdQuery(id));
            return Ok(resp);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLibrosPaged([FromQuery] GetLibrosPagedQuery query)
        {
            var resp = await _mediator.Send(query);
            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateLibro(CreateLibroCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
