using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Extensions;
using Infrastructure.Context;
using MediatR;

namespace Application.Domain.Libros.Query.GetLibrosPaged
{
    public class GetLibrosPagedHandler : IRequestHandler<GetLibrosPagedQuery, PaginatedList<GetLibrosPagedDTO>>
    {
        private readonly LibraryContext _context;

        public GetLibrosPagedHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<GetLibrosPagedDTO>> Handle(GetLibrosPagedQuery request, CancellationToken cancellationToken)
        {
            return await _context.Libros
                .OrderBy(x => x.Titulo)
                .Select(x => new GetLibrosPagedDTO
                {
                    Isbn = x.Isbn,
                    Titulo = x.Titulo,
                    Editorial = x.Editorial.Nombre,
                    N_Paginas = x.N_Paginas
                })
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
