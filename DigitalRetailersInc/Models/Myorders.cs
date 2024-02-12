using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalRetailersInc.Models
{
    [Table("Myorders")]
    public class Myorders
    {
        [Key]
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public LaptopDetails LaptopDetails { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public string paymentStatus { get; set; }
        public string DeleveryStatus { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime ExpDeleveyDate { get; set; }
    }
}
