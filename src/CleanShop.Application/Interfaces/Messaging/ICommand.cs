namespace CleanShop.Application.Interfaces.Messaging
{
    public interface ICommand;
    public interface ICommand<TResponse> : ICommand;
}
