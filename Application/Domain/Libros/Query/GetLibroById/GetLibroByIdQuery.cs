using Application.Configurations.Queries;

namespace Application.Domain.Libros.Query.GetLibroById
{
    public record GetLibroByIdQuery(int Id) : IQuery<GetLibroByIdDTO>;
}
