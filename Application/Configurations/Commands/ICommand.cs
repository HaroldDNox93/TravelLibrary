using MediatR;

namespace Application.Configurations.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
