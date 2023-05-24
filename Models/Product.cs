using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Products { get; set; }

        public int Price { get; set; }
    }
}
