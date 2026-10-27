using FluentValidation.TestHelper;
using ProductManagement.Features.Products.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Tests.Features.Products.UpdateProduct;

public class UpdateProductValidatorTests
{
    private readonly UpdateProductValidator _validator = new();
    [Fact]
    public void Validate_WhenIdIsZero_ShouldHaveValidationError()
    {
        // Arrange
        var command = new UpdateProductCommand(0, "Keyboard", 100);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Fact]
    public void Validate_WhenPriceIsNegative_ShouldHaveValidationError()
    {
        // Arrange
        var command = new UpdateProductCommand(1, "Keyboard", -50);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }

    [Fact]
    public void Validate_WhenDataIsValid_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var command = new UpdateProductCommand(1, "Keyboard", 100);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
