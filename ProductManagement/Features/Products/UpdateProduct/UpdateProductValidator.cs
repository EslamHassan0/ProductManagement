using FluentValidation;

namespace ProductManagement.Features.Products.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Product ID must be greater than zero.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required.")
            .MaximumLength(200)
            .WithMessage("Product name cannot exceed 200 characters.");


        RuleFor(x => x.Price)
              .GreaterThan(0)
              .WithMessage("Product price must be greater than zero.");

    }
}
