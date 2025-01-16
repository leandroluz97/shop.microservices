namespace Common.Pagination
{
    public class PaginationResult<TEntity>
        (int pageNumber, int pageSize, int count, IEnumerable<TEntity> data) 
        where TEntity : class
    {
        public int PageNumber { get; } = pageNumber;
        public int PageSize { get; } = pageSize;
        public int Count { get; } = count;
        public IEnumerable<TEntity> Data { get; } = data;
    }
}
