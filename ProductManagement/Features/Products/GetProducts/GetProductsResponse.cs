namespace ProductManagement.Features.Products.GetProducts;

public record GetProductsResponse
(
    IEnumerable<ProductItemResponse> Products
);
public record ProductItemResponse(
     int Id,
    string Name,
    decimal Price);
