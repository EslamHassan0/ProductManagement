namespace ProductManagement.Features.Products.GetProduct;

public record GetProductResponse(int Id,
    string Name,
    decimal Price);