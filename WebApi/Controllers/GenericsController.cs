using System.Text;
using Application.Domain.Generics.Query.GetAutoresSelect;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Domain.Generics.Query.GetEditorialesSelect;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenericsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAutoresSelect(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) nombre = string.Empty;
            var autores = await _mediator.Send(new GetAutoresSelectQuery(nombre));
            return Ok(autores);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEditorialesSelect(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) nombre = string.Empty;
            var editoriales = await _mediator.Send(new GetEditorialesSelectQuery(nombre));
            return Ok(editoriales);
        }


    }
}
