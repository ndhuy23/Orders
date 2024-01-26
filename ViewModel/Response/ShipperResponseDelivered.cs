namespace Orders.ViewModel.Response
{
    public class ShipperResponseDelivered
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int AmountDelivered { get; set; }

        public ShipperResponseDelivered(string code, string name, int amountDelivered)
        {
            Code = code;
            Name = name;
            AmountDelivered = amountDelivered;
        }
    }
}
