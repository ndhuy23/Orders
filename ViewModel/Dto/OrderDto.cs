using System.ComponentModel.DataAnnotations;

namespace Orders.ViewModel.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
        }
        public string OrderCode { get; set; }
        public int TotalPrice { get; set; }
    }
}
