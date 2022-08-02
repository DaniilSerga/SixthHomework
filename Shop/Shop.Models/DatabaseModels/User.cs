using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DatabaseModels
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int Age { get; set; }

        public byte[] PasswordHash { get; set; } = null!;

        public byte[] PasswordSalt { get; set; } = null!;

        public List<Sale> Sells { get; set; } = new();
    }
}
