using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace projectDemo.models
{
    public class products
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
