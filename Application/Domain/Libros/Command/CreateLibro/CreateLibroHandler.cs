using System.Threading;
using System.Threading.Tasks;
using Application.Configurations.Commands;
using Application.Exceptions;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Domain.Libros.Command.CreateLibro
{
    public class CreateLibroHandler : ICommandHandler<CreateLibroCommand, int>
    {
        private readonly LibraryContext _context;

        public CreateLibroHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
        {
            var editorial = await _context.Editoriales
                .FirstOrDefaultAsync(x => x.Id == request.EditorialId, cancellationToken);

            var libro = new Libro()
            {
                Titulo = request.Titulo,
                Sinopsis = request.Sinopsis,
                N_Paginas = request.N_Paginas,
                Editorial = editorial
            };

            _context.Libros.Add(libro);

            await _context.SaveChangesAsync(cancellationToken);

            foreach (int autorId in request.AutoresId)
            {
                var autor_has_libro = new AutorHasLibro()
                {
                    Autor_Id = autorId,
                    Libro_Isbn = libro.Isbn
                };

                _context.AutoresHasLibros.Add(autor_has_libro);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return libro.Isbn;
        }
    }
}
