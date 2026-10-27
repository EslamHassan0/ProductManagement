using MediatR;

namespace ProductManagement.Features.Products.GetProducts;

public record GetProductsQuery : IRequest<GetProductsResponse>;

