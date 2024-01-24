using System;
using System.ComponentModel.DataAnnotations;

public class Order
{
    public Order()
    {
        Deliveries = new List<Delivery>();
        Status = "Pending";
    }
    public Order(string OrderCode, int TotalPrice)
    {
        this.OrderCode = OrderCode;
        this.TotalPrice = TotalPrice;
        Deliveries = new List<Delivery>();
        Status = "Pending";
    }
    [Key]
    public int OrderId { get; set; }
    public string OrderCode { get; set; }
    public int TotalPrice { get; set; }
    public string Status { get; set; }
    public IList<Delivery> Deliveries { get; set; }
    
}
