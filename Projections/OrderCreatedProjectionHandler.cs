
using MediatR;

public class OrderCreatedProjectionHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly ReadDbContext _context;

    public OrderCreatedProjectionHandler(ReadDbContext context)
    {
        _context = context;
    }

  
    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = notification.OrderId,
            FirstName = notification.FirstName,
            LastName = notification.LastName,
            Status = "Created",
            CreatedAt = DateTime.Now,
            TotalCost = notification.TotalCost
        };

        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}