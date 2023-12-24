using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectDemo.models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product name")]
        public string productName { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int quantity { get; set; }
    }
}