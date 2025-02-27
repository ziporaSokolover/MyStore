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
            //CreateMap<getCategoryDTO, Category>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTOPost, Order>();
            CreateMap<Product, ProductDTO>();
            CreateMap<AddUserDTO, User>(); 
            CreateMap<User, ReturnPostUserDTO>(); 
            //CreateMap<LoginUserDTO, User>(); 
            CreateMap<User, ReturnLoginUserDTO>();
           
            //CreateMap<Order, OrderDTO>();
            //CreateMap<OrderDTOPost, Order>();
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<OrderItem, OrderItemDTO>();



        }



    }
}
