namespace Domain.Entities
{
    public class AutorHasLibro
    {
        public int Autor_Id { get; set; }
        public virtual Autor Autor { get; set; }
        public int Libro_Isbn { get; set; }
        public virtual Libro Libro { get; set; }
    }
}
