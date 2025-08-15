using MediatR;

public record OrderCreatedEvent
(
    int OrderId,
    string FirstName,
    string LastName,
    decimal TotalCost
) : INotification;