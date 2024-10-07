


namespace Catalog.API.Products.DeleteProductById
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
        }
    }

    public record DeleteProductResult(bool isSuccess);
    internal class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            //logger.LogInformation("DeleteProductCommandHandler. Handler called with {@query}", command);
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
