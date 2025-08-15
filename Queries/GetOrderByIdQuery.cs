using MediatR;

public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto?>;