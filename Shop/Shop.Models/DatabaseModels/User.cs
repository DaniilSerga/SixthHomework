using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DatabaseModels
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public List<Sale> Sells { get; set; } = new();
    }
}
