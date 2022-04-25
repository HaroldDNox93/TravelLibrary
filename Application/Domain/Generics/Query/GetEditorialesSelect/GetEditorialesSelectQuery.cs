using Application.Configurations.Queries;
using Application.Responses.Generics;

namespace Application.Domain.Generics.Query.GetEditorialesSelect
{
    public record GetEditorialesSelectQuery(string Nombre) : IQuery<GetGenericSelectResponse>;
}
