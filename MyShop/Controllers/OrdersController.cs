using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService service;
        IMapper _mapper;
        public OrdersController(IOrderService service, IMapper _mapper)
        {
            this.service = service; 
            this._mapper = _mapper;

        }

       

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            var order = await service.GetById(id);
            if (order != null)
            {
                return Ok(_mapper.Map<Order, OrderDTO>(order));
            }
            return NoContent();
        }


        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTOPost order)
        {
            Order newOrder=_mapper.Map<OrderDTOPost, Order>(order);
            newOrder = await service.Post(newOrder);
            if (newOrder != null)
            {
                return Ok(_mapper.Map<Order, OrderDTO>(newOrder));
            }
            return NoContent();
        }












    }
}
