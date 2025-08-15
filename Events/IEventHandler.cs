using Microsoft.EntityFrameworkCore.Diagnostics;

public interface IEventHandler<TEvent>
{
    Task HandleAsync(TEvent evt);
}