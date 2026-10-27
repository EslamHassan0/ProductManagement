using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Features.Products.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResponse>
{
    private readonly AppDbContext _dbContext;

    public GetProductHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
             .AsNoTracking()
             .FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException(
                $"Product with id {request.Id} was not found.");
        }

        return new GetProductResponse(
           product.Id,
           product.Name,
           product.Price);
    }
}
