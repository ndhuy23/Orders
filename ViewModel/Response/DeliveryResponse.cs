namespace Orders.ViewModel.Response
{
    public class DeliveryResponse
    {
        public string OrderCode { get; set; }
        public int TotalPrice { get; set; }
        public string DeliveryCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public string ShipperCode { get; set; }
        public string ShipperName { get; set;}

        public DeliveryResponse(string orderCode, int totalPrice, string deliveryCode, DateTime deliveryDate, string status, string shipperCode, string shipperName)
        {
            OrderCode = orderCode;
            TotalPrice = totalPrice;
            DeliveryCode = deliveryCode;
            DeliveryDate = deliveryDate;
            Status = status;
            ShipperCode = shipperCode;
            ShipperName = shipperName;
        }
        public DeliveryResponse()
        {

        }
    }
}
