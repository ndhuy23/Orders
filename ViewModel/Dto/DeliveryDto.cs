namespace Orders.ViewModel.Dto
{
    public class DeliveryDto
    {
        public int OrderId { get; set; }
        public int ShipperId { get; set; }

        public DeliveryDto(int orderId, int shipperId)
        {
            OrderId = orderId;
            ShipperId = shipperId;
        }
    }
}
