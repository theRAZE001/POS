using BillManagement.Models;

namespace BillManagement.DTO
{
    public class NewDC: Dctable
    {
        public List<ProductDCDto> Products { get; set; }
    }
}
