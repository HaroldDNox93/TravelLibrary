namespace Application.Domain.Libros.Query.GetLibrosPaged
{
    public class GetLibrosPagedDTO
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string N_Paginas { get; set; }
    }
}
