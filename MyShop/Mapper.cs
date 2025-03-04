using AutoMapper;
using Entities;
using DTO;
using static DTO.UserDTO;


namespace MyShop
{
    public class Mapper:Profile
    {
        public Mapper() { 
            
            
            CreateMap<Category, getCategoryDTO>();
           
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTOPost, Order>();
            CreateMap<Product, ProductDTO>();
            CreateMap<AddUserDTO, User>(); 
            CreateMap<User, ReturnPostUserDTO>(); 
           
            CreateMap<User, ReturnLoginUserDTO>();
           
          
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<OrderItem, OrderItemDTO>();



        }



    }
}
