using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace project2.Models
{
    public class Order
    {
        [DisplayName("ID заказа")]
        public int OrderId { get; set; }
        [DisplayName("Город отправителя")]
        public string? SenderCity { get; set; }
        [DisplayName("Адрес отправителя")]
        public string? SenderAddress { get; set; }
        [DisplayName("Город получателя")]
        public string? ReceiverCity { get; set; }
        [DisplayName("Адрес получателя")]
        public string? ReceiverAddress { get; set; }
        [DisplayName("Вес груза в граммах")]
        public double Weight { get; set; }
        [DisplayName("Дата отправки")]
        public DateTime PickupDate { get; set; } = DateTime.Now;
        [DisplayName("Номер заказа")]
        public string OrderNumber { get; set; } = Guid.NewGuid().ToString();
    }
}
