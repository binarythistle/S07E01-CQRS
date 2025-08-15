using MediatR;

public record GetOrderSummariesQuery() : IRequest<List<OrderSummaryDto>>;