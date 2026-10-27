using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Features.Products.GetProduct;
using ProductManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Tests.Features.Products.GetProduct;

public class GetProductHandlerTests
{
    [Fact]
    public async Task Handle_WhenProductExists_ShouldReturnProduct()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var dbContext = new AppDbContext(options);

        var product = new Product("Keyboard", 100);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        var handler = new GetProductHandler(dbContext);
        var query = new GetProductQuery(product.Id);

        // Act
        var result = await handler.Handle(
            query,
            CancellationToken.None);

        // Assert
        Assert.Equal(product.Id, result.Id);
        Assert.Equal("Keyboard", result.Name);
        Assert.Equal(100m, result.Price);
    }

    [Fact]
    public async Task Handle_WhenProductDoesNotExist_ShouldThrowKeyNotFoundException()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var dbContext = new AppDbContext(options);

        var handler = new GetProductHandler(dbContext);
        var query = new GetProductQuery(999);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(
            () => handler.Handle(query, CancellationToken.None));
    }
}
