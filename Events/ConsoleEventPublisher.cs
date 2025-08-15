
public class ConsoleEventPublisher : IEventPublisher
{
    public Task PublishAsync<TEvent>(TEvent evt)
    {
        Console.WriteLine($"--> Event published: {evt}");
        return Task.CompletedTask;
    }
}