using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Configurations.Queries;
using Application.Responses.Generics;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Domain.Generics.Query.GetAutoresSelect
{
    public class GetAutoresSelectHandler : IQueryHandler<GetAutoresSelectQuery, GetGenericSelectResponse>
    {
        private readonly LibraryContext _context;

        public GetAutoresSelectHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<GetGenericSelectResponse> Handle(GetAutoresSelectQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Autores
                .Where(x => x.Nombre.Contains(request.Nombre) || x.Apellidos.Contains(request.Nombre))
                .Select(x => new SelectEntity
                {
                    Id = x.Id,
                    Nombre = x.Nombre+" "+x.Apellidos
                })
                .OrderBy(x => x.Nombre)
                .ToListAsync(cancellationToken);

            return new GetGenericSelectResponse
            {
                Data = response
            };
        }
    }
}
