using Application.Common.Models;
using Application.Configurations.Queries;

namespace Application.Domain.Libros.Query.GetLibrosPaged
{
    public record GetLibrosPagedQuery() : IQuery<PaginatedList<GetLibrosPagedDTO>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
