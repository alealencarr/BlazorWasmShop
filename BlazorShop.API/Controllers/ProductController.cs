using BlazorShop.API.Repositories.Ports;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorShop.API.Mappings;

namespace BlazorShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItens()
        {
            try
            {
                var products = await _productRepository.GetItens();
                if (products is null)
                {
                    return BadRequest();
                }
                else
                {
                    var productsDtos = products.CastProductsToDto();
                    return Ok(products);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in access to database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await _productRepository.GetItem(id);
                if (product is null)
                {
                    return BadRequest();
                }
                else
                {
                    var productDto = product.CastProductToDto();
                    return Ok(productDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in access to database.");
            }
        }

        [HttpGet("GetItensByCategory/{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItensByCategory(int categoryId)
        {
            try
            {
                var products = await _productRepository.GetItensByCategory(categoryId);
                if (products is null)
                {
                    return BadRequest();
                }
                else
                {
                    var productsDtos = products.CastProductsToDto();
                    return Ok(products);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error in access to database.");
            }
        }
    }
}
