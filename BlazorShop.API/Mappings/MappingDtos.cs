using BlazorShop.API.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.API.Mappings
{
    public static class MappingDtos
    {
        public static IEnumerable<CategoryDto> CastCategoriesToDto(this IEnumerable<CategoryDto> categories)
        {
            return (from category in categories
                    select new CategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IconCSS = category.IconCSS
                    }).ToList();
        }

        public static IEnumerable<ProductDto> CastProductsToDto(this IEnumerable<Product> products)
        {
            return (from product in products
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Amount = product.Amount,
                        CategoryId = product.Category.Id,
                        CategoryName = product.Category.Name
                    }).ToList();
        }

        public static ProductDto CastProductToDto(this Product product)
        {
            return ( new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Amount = product.Amount,
                        CategoryId = product.Category.Id,
                        CategoryName = product.Category.Name
                    });
        }

        public static IEnumerable<CartItemDto> CastCartItensForDto(this IEnumerable<CartItem> cartItens, IEnumerable<Product> products)
        {
            return (from cartItem in cartItens
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageUrl = product.ImageUrl,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Amount = cartItem.Amount,
                        PriceTotal = product.Price * cartItem.Amount
                    }).ToList();
        }

        public static CartItemDto CastCartItemForDto(this CartItem cartItem, Product product)
        {
            return (new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageUrl = product.ImageUrl,
                Price = product.Price,
                CartId = cartItem.CartId,
                Amount = cartItem.Amount,
                PriceTotal = product.Price * cartItem.Amount
            });
        }
    }
}
