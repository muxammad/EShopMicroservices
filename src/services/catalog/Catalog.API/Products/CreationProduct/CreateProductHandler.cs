using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreationProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price) : ICommand<bool>;

    public class CreateProductHandler : ICommandHandler<CreateProductCommand, bool>
    {
        public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            };

            return true;

        }
    }

}
