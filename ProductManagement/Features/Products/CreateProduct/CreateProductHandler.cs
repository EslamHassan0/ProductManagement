using MediatR;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement.Features.Products.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly AppDbContext _dbContext;

    public CreateProductHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price);
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new CreateProductResponse(
          product.Id,
          product.Name,
          product.Price);
    }
}
