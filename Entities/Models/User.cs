using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
	public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Position { get; set; }

       
        public ICollection<Post> Posts { get; set; }
    }
}
