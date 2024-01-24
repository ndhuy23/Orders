using System;
using System.ComponentModel.DataAnnotations;

public class Shipper
{
    public Shipper()
    {
        Deliveries = new List<Delivery>();
    }
    [Key]
    public int ShipperId { get; set; }
    public string Code { get; set; }
	public string Name { get; set; }
    public IList<Delivery> Deliveries { get; set; }
}
