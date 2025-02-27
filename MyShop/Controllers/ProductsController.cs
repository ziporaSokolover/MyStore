using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService service;
        IMapper _mapper;


       
        public ProductsController(IProductService service, IMapper _mapper)
        {
            this.service = service;
            this._mapper = _mapper;

        }



        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds,[FromQuery] string? desc)
        {
            List<Product> products = await service.Get( minPrice, maxPrice,  categoryIds, desc);
            if (products != null)
            {
                return Ok(_mapper.Map<List<Product>, List<ProductDTO>>(products));
            }


            return NoContent();
        }

        
    }
}
