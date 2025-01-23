
namespace Ordering.Application.Orders.Queries.GetOrders
{
    public class GetOrdersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var pageNumber = query.PaginationOptions.PageNumber;
            var pageSize = query.PaginationOptions.PageSize;

            var ordersCount = await dbContext.Orders.LongCountAsync(cancellationToken);

            var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .OrderBy(o => o.OrderName.Value)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var result = new PaginationResult<OrderDto>(pageNumber, pageSize, ordersCount, orders.ToOrderDtoList());
            return new GetOrdersResult(result);
        }
    }
}
