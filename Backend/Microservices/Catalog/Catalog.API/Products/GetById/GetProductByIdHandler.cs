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
    public class GetProductByIdHandler(IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(query.Id);
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
