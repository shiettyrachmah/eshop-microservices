namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
        }
    }

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //var result = await validator.ValidateAsync(command, cancellationToken);
            //var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            //if (errors.Any())
            //{
            //    throw new ValidationException(errors.FirstOrDefault());
            //}
            //logger.LogInformation("CreateProductCommandHandler. Handle called with {@command}", command);

            //create product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Category = command.Category
            };

            //save product
            session.Store(product); //disimpan ke dalam session 
            await session.SaveChangesAsync(cancellationToken);

            //return product
            return new CreateProductResult(product.Id);

        }
    }

}
