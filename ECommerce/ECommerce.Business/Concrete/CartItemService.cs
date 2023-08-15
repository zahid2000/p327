using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ECommerce.Business.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.Entities.Dtos.CartItems;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ECommerce.Business.Concrete;

public class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IProductService _productService;
    private readonly bool _isAuthenticated;
    private const string COOKIE_CART_ITEM_KEY = "mycartitemkey";

    public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, IHttpContextAccessor contextAccessor, IProductService productService)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _isAuthenticated = _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        _productService = productService;
    }
    public async Task<IDataResult<List<CartItemDetailDto>>> GetAllAsync()
    {
        List<CartItem> cartItems = new List<CartItem>();
        if (!_isAuthenticated)
        {
            cartItems=GetCartItemsFromCookie();
            cartItems=await GetProducToCartItemsAsync(cartItems);
        }
        else
            cartItems=await _cartItemRepository.GetAllAsync(includes:new string[] { "Product" });
        var result = _mapper.Map<List<CartItemDetailDto>>(cartItems);
        return new SuccessDataResult<List<CartItemDetailDto>>(result);
    }

    public Task<IDataResult<CartItemDetailDto>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult> AddAsync(CartItemCreateDto dto)
    {
        CartItem cartItem = _mapper.Map<CartItem>(dto);
        if (_isAuthenticated)
            await _cartItemRepository.AddAsync(cartItem);
        else
            await AddCartItemToCookieAsync(cartItem);
        return new SuccessResult("Added");
    }


    public Task<IResult> UpdateAsync(CartItemUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    private async Task AddCartItemToCookieAsync(CartItem item)
    {
        List<CartItem> cartItems = GetCartItemsFromCookie();
        if (cartItems != null)
            if (cartItems.Any(c => c.ProductId == item.ProductId))
                cartItems.FirstOrDefault(c => c.ProductId == item.ProductId)!.Count += item.Count;
            else
                cartItems.Add(item);
        else
            cartItems = new List<CartItem> { item };

        _contextAccessor.HttpContext.Response.Cookies.Append(COOKIE_CART_ITEM_KEY, JsonConvert.SerializeObject(cartItems));
    }


    private List<CartItem> GetCartItemsFromCookie()
    {
        List<CartItem> cartItems = null;
        if (_contextAccessor.HttpContext.Request.Cookies[COOKIE_CART_ITEM_KEY] != null)
            cartItems = JsonConvert.DeserializeObject<List<CartItem>>(_contextAccessor.HttpContext.Request.Cookies[COOKIE_CART_ITEM_KEY]);
        return cartItems;
    }

    private  async Task<List<CartItem>> GetProducToCartItemsAsync(List<CartItem> cartItems)
    {
        foreach (var cartItem in cartItems)
            cartItem.Product = _mapper.Map<Product>((await _productService.GetById(cartItem.ProductId)).Data);
        return cartItems;
    }
}
