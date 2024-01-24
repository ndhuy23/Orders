namespace Orders.ViewModel.Dto
{
    public class CreateOrderDto
    {
        public string OrderCode { get; set; }
        public int TotalPrice { get; set; }
        public string ShipperCode { get; set; }

    }
}
