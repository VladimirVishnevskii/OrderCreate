using Microsoft.AspNetCore.Mvc.Rendering;

namespace project2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? SenderCity { get; set; }
        public string? SenderAddress { get; set; }
        public string? ReceiverCity { get; set; }
        public string? ReceiverAddress { get; set; }
        public double Weight { get; set; }
        public DateTime PickupDate { get; set; } = DateTime.Now;
        //Номер заказа GUID
        public string OrderNumber { get; set; } = Guid.NewGuid().ToString();
    }
}
