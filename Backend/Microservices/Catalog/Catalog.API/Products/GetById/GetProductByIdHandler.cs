using Catalog.API.Exceptions;
using Catalog.API.Products.GetAll;

namespace Catalog.API.Products.GetById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price);
    public class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if(product is null)
            {
                throw new ProductNotFoundException();
            }

            return new GetProductByIdResult(
                product.Name, 
                product.Category, 
                product.Description, 
                product.ImageFile, 
                product.Price);
        }
    }
}
