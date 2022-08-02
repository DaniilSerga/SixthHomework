using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DatabaseModels
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public decimal Price { get; set; }

        public List<Sale> Sells { get; set; } = new();
    }
}
