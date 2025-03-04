using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    
    public record OrderDTO(int OrderId,DateTime? OrdetDate, int OrderSum, int UserId);
    public record OrderDTOPost(int UserId, List<OrderItemDTO> OrderItems, int OrderSum);

    public record OrderItemDTO( int? ProductId, int? Quantity);



}
