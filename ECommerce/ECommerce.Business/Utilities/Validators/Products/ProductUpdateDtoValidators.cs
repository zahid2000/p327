using ECommerce.Business.Abstract;
using ECommerce.Entities.Dtos.Products;
using FluentValidation;

namespace ECommerce.Business.Utilities.Validators.Products;

public class ProductUpdateDtoValidators : AbstractValidator<ProductUpdateDto>
{
    //private readonly IProductService _productService;



    //public ProductUpdateDtoValidators(IProductService productService)
    //{
    //    _productService = productService;
    //    RuleFor(x => x.Name).MustAsync(async (name, cancellation) =>
    //    {

    //        return false;
    //    }).WithMessage("ID Must be unique");

    //}
    //public async Task<bool> CheckProductIsExists(string name, CancellationToken cancellationToken)
    //{
    //    return await _productService.IsExistsByName(name);
    //}
}
