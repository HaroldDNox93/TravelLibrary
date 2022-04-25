using System.Collections.Generic;

namespace Application.Domain.Libros.Query.GetLibroById
{
    public class GetLibroByIdDTO
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_Paginas { get; set; }
        public string Editorial { get; set; }
        public List<string> Autores { get; set; }
    }
}
