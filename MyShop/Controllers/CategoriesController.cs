using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using DTO;
using System.Collections.Generic;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers


     
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService service;
        IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper _mapper)
        {
            this.service = service;
            this._mapper = _mapper;

        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<getCategoryDTO>>> Get()
        {
            List <Category> category = await service.Get();
            if (category != null)
            {
                return Ok(_mapper.Map < List<Category>,List<getCategoryDTO>>(category));
            }


            return NoContent();
        }

    }
}
