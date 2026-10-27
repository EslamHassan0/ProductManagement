using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Features.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly AppDbContext _dbContext;

    public UpdateProductHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if(product == null)
            throw new KeyNotFoundException(
               $"Product with id {request.Id} was not found.");

        product.Update(request.Name, request.Price);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
