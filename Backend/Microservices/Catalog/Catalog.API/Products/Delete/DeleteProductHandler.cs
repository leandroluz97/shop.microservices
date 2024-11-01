﻿using Catalog.API.Exceptions;
using Catalog.API.Products.Update;

namespace Catalog.API.Products.Delete
{
    public record DeleteProductCommand(Guid Id) : ICommand<Unit>;
    public class DeleteProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger) : ICommandHandler<DeleteProductCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductHandler.Handle called with {@Command}", command);

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken) ?? throw new ProductNotFoundException();

            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
