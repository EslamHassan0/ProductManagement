using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Features.Products.DeleteProduct;
using ProductManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Tests.Features.Products.DeleteProduct;

public class DeleteProductHandlerTests
{
    [Fact]
    public async Task Handle_WhenProductExists_ShouldDeleteProduct()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var dbContext = new AppDbContext(options);

        var product = new Product("Keyboard", 100);
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        var productId = product.Id;
        var handler = new DeleteProductHandler(dbContext);
        var command = new DeleteProductCommand(productId);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        var deletedProduct = await dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        Assert.Null(deletedProduct);
    }
}
