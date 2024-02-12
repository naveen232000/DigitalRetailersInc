using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalRetailersInc.Models
{
    [Table("LaptopDetails")]
    public class LaptopDetails
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public byte[] Img { get; set; }

    }
}
