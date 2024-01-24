using System.ComponentModel.DataAnnotations;

namespace Orders.ViewModel.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
            Deliveries = new List<Delivery>();
        }
        public string OrderCode { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public IList<Delivery> Deliveries { get; set; }
    }
}
