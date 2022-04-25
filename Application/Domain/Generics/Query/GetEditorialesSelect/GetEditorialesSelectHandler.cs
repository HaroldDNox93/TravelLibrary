using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Configurations.Queries;
using Application.Responses.Generics;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Domain.Generics.Query.GetEditorialesSelect
{
    public class GetEditorialesSelectHandler : IQueryHandler<GetEditorialesSelectQuery, GetGenericSelectResponse>
    {
        private readonly LibraryContext _context;

        public GetEditorialesSelectHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<GetGenericSelectResponse> Handle(GetEditorialesSelectQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.Editoriales
                .Where(x => x.Nombre.Contains(request.Nombre))
                .Select(x => new SelectEntity
                {
                    Id = x.Id,
                    Nombre = x.Nombre+" - "+x.Sede
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
