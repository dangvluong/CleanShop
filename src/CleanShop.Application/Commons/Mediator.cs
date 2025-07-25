using CleanShop.Application.Commons.Interfaces.Messaging;

namespace CleanShop.Application.Commons;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetService(handlerType);

        if (handler == null)
        {
            throw new InvalidOperationException($"No handler registered for request type {request.GetType().Name}");
        }

        var method = handlerType.GetMethod("Handle");
        return await (Task<TResponse>)method.Invoke(handler, new object[] { request, cancellationToken });
    }

    public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetService(handlerType);

        if (handler == null)
        {
            throw new InvalidOperationException($"No handler registered for request type {request.GetType().Name}");
        }

        var method = handlerType.GetMethod("Handle");
        return await (Task<TResponse>)method.Invoke(handler, new object[] { request, cancellationToken });
    }
}