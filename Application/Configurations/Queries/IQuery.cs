using MediatR;

namespace Application.Configurations.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse> { }
}
