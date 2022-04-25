using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Configurations.Queries;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Domain.Libros.Query.GetLibroById
{
    public class GetLibroByIdHandler : IQueryHandler<GetLibroByIdQuery, GetLibroByIdDTO>
    {
        private readonly LibraryContext _context;

        public GetLibroByIdHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<GetLibroByIdDTO> Handle(GetLibroByIdQuery request, CancellationToken cancellationToken)
        {
            var autores = await _context.AutoresHasLibros
                .Include(x => x.Autor)
                .Where(x => x.Libro_Isbn == request.Id)
                .Select(x => x.Autor.Nombre+" "+x.Autor.Apellidos)
                .ToListAsync(cancellationToken);

            return await _context.Libros
                .Select(x => new GetLibroByIdDTO()
                {
                    Isbn = x.Isbn,
                    Titulo = x.Titulo,
                    Sinopsis = x.Sinopsis,
                    N_Paginas = x.N_Paginas,
                    Editorial = x.Editorial.Nombre,
                    Autores = autores
                })
                .FirstOrDefaultAsync(x => x.Isbn == request.Id, cancellationToken);
        }
    }
}
