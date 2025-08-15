public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent evt);
}