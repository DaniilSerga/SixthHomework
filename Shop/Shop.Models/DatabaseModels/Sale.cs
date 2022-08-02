using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DatabaseModels
{
    [Table("Sells")]
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = new();

        public int ProductId { get; set; }
        public Product Product { get; set; } = new();

        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
