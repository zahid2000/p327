using ECommerce.Entities.Dtos.Products;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.Net.Http.Headers;

namespace ECommerce.Business.Utilities.Validators.Products;

public class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(p=>p.Name)
                .NotEmpty().WithMessage("Product name must not be  empty!")
                .NotNull().WithMessage("Product name must not be  null!")
                .MinimumLength(2).WithMessage("Minimum 2 simvol olmalidir")
                .MaximumLength(100)
                .Must(CheckName).WithMessage("Name must start with 'a'!");
        RuleFor(p => p.Price)
            .GreaterThan(20).WithMessage("Qiymet minimum 20$ olmalidir")
            .LessThanOrEqualTo(20000);

    }
    public bool CheckName(string name)
    {
        return name.ToLower().StartsWith("a");
    }
}
