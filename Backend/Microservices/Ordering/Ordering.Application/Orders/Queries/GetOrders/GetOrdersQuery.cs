using Common.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders
{
    public record GetOrdersQuery(PaginationOptions PaginationOptions) : IQuery<GetOrdersResult>;
    public record GetOrdersResult(PaginationResult<OrderDto> Orders);

}
