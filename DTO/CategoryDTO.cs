using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    
    //public record getCategoryDTO(string CategoryName, List<ProductDTO> ProductsProductName);
    //public record getCategoryDTO(int CategoryId, string CategoryName, List<ProductDTO> Products);
    public record getCategoryDTO(int CategoryId, string CategoryName);

}
