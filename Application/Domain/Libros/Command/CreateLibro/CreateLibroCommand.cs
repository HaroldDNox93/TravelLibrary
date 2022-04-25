using System.Collections.Generic;
using Application.Configurations.Commands;

namespace Application.Domain.Libros.Command.CreateLibro
{
    public class CreateLibroCommand : ICommand<int>
    {
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_Paginas { get; set; }
        public int EditorialId { get; set; }
        public List<int> AutoresId { get; set; }
    }
}
