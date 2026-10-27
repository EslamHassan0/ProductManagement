using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Features.Products.UpdateProduct;
using ProductManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Tests.Features.Products.UpdateProduct;

public class UpdateProductHandlerTests
{
    [Fact]
    public async Task Handle_WhenProductExists_ShouldUpdateProduct()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var dbContext = new AppDbContext(options);

        var product = new Product("Keyboard", 100);
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        var handler = new UpdateProductHandler(dbContext);
        var command = new UpdateProductCommand(
            product.Id, "Mechanical Keyboard", 150);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        var updatedProduct = await dbContext.Products
            .AsNoTracking()
            .FirstAsync(p => p.Id == product.Id);

        Assert.Equal("Mechanical Keyboard", updatedProduct.Name);
        Assert.Equal(150m, updatedProduct.Price);
    }
}
