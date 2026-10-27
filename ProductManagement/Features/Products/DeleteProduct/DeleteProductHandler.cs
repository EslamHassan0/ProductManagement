using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Features.Products.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly AppDbContext _dbContext;

    public DeleteProductHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
             .FirstOrDefaultAsync(
                 p => p.Id == request.Id,
                 cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException(
                $"Product with id {request.Id} was not found.");
        }

        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
