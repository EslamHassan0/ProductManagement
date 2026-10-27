using FluentValidation.TestHelper;
using ProductManagement.Features.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Tests.Features.Products.CreateProduct;

public class CreateProductValidatorTests
{
    private readonly CreateProductValidator _validator = new();


    [Fact]
    public void Validate_WhenNameIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var command = new CreateProductCommand("", 100);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Validate_WhenPriceIsNegative_ShouldHaveValidationError()
    {
        // Arrange
        var command = new CreateProductCommand("Keyboard", -50);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }

    [Fact]
    public void Validate_WhenDataIsValid_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var command = new CreateProductCommand("Keyboard", 100);

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
