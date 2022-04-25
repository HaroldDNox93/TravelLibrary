using System.Collections.Generic;

namespace Domain.Entities
{
    public class Libro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_Paginas { get; set; }
        public int EditorialId { get; set; }
        public virtual Editorial Editorial { get; set; }
        public virtual ICollection<AutorHasLibro> AutoresHasLibros { get; set; }
    }
}
