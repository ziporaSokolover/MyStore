using Entities;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserDTO
    {

        public record AddUserDTO(string Password,string Email, string? LastName, string? FirstName);
        public record ReturnPostUserDTO( string Email, string? LastName, string? FirstName, int UserId);

        //public record LoginUserDTO(string Password, string Email);

        public record ReturnLoginUserDTO(int UserId,string Email, string? LastName, string? FirstName);

        //, List<int> OrdersOrderId




        //public int UserId { get; set; }
        //[Required(ErrorMessage = "password required")]
        //public string Password { get; set; } = null!;
        //[EmailAddress, Required]
        //public string Email { get; set; } = null!;
        //[StringLength(15, ErrorMessage = "LastName can be between 2 till 15", MinimumLength = 2)]
        //public string? LastName { get; set; }
        //[StringLength(15, ErrorMessage = "FirstName can be between 2 till 15", MinimumLength = 2)]
        //public string? FirstName { get; set; }

        //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
