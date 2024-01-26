using System;
using System.ComponentModel.DataAnnotations;

public class Delivery
{
    [Key]
    public int DeliveryId { get; set; }
    public string DeliveryCode { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string Status { get; set; }
    public Order Order { get; set; }
    public Shipper Shipper { get; set; }
    public int OrderId {  get; set; }
    public int ShipperId {  get; set; }
    public Delivery()
	{
	}
}
