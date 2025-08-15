using FluentValidation;
using MediatR;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly WriteDbContext _context;
    private readonly IValidator<CreateOrderCommand> _validator;
    private readonly IMediator _mediator;

    public CreateOrderCommandHandler(
        WriteDbContext context,
        IValidator<CreateOrderCommand> validator,
        IMediator mediator)
    {
        _context = context;
        _validator = validator;
        _mediator = mediator;
    }

   

    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var order = new Order
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Status = request.Status,
            CreatedAt = DateTime.Now,
            TotalCost = request.TotalCost
        };

        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var orderCreatedEvent = new OrderCreatedEvent
        (
            order.Id,
            order.FirstName,
            order.LastName,
            order.TotalCost
        );

        //await _eventPublisher.PublishAsync(orderCreatedEvent);

        await _mediator.Publish(orderCreatedEvent);

        return new OrderDto(
            order.Id,
            order.FirstName,
            order.LastName,
            order.Status,
            order.CreatedAt,
            order.TotalCost
        );
    }
    
    
}