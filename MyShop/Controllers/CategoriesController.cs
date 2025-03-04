
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MyShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService service;
        IMapper _mapper;
        IMemoryCache _memoryCache;

        public CategoriesController(ICategoryService service, IMapper _mapper, IMemoryCache memoryCache)
        {
            this.service = service;
            this._mapper = _mapper;
            this._memoryCache = memoryCache;
        }

       





      // GET: api/<CategoryController>
      [HttpGet]
       public async Task<ActionResult<List<getCategoryDTO>>> Get()
       {
         if (!_memoryCache.TryGetValue("categories", out List<Category> categories))
          {
               categories = await service.Get();
                _memoryCache.Set("categories", categories, TimeSpan.FromMinutes(30));
          }
         if (categories != null)
         {
         return Ok(_mapper.Map<List<Category>, List<getCategoryDTO>>(categories));
         }

        return NoContent();
}


    }
}





   















