namespace CleanShop.Application.Commons.Interfaces.Messaging;

public interface IMediator
{
    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken = default);

    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken = default);
}