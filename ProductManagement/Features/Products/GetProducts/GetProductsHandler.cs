using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Features.Products.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, GetProductsResponse>
{
    private readonly AppDbContext _dbContext;

    public GetProductsHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetProductsResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
             .AsNoTracking()
             .Select(product => new ProductItemResponse(product.Id, product.Name, product.Price))
             .ToListAsync(cancellationToken);

        return new GetProductsResponse(product);
    }
}
