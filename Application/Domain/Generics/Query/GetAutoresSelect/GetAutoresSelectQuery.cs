using Application.Configurations.Queries;
using Application.Responses.Generics;

namespace Application.Domain.Generics.Query.GetAutoresSelect
{
    public record GetAutoresSelectQuery(string Nombre) : IQuery<GetGenericSelectResponse>;
}
