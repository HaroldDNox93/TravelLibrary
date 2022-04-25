using System.Collections.Generic;
using Domain.Contracts;

namespace Domain.Entities
{
    public class Autor : BaseEntity
    {
        public string Apellidos { get; set; }
        public virtual ICollection<AutorHasLibro> AutoresHasLibros { get; set; }
    }
}
