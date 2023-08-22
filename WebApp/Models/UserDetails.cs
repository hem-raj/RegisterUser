#nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegisterUserAPI.Models
{
    public class UserDetails{
        [Key]
        public int Id{ get; set; }

        [MaxLength(50)]
        public string FirstName{ get; set; }

        [MaxLength(50)]
        public string LastName{ get; set;}

        [MaxLength(50)]
        [Required]
        public string Email{ get; set; }

        [MaxLength(50)]
        [Required]
        [Category("Security")]
        [DataType(DataType.Password)]
        [PasswordPropertyText(true)]
        public string Password{ get; set; }

        [MaxLength(50)]
        public string Role{ get; set; }
    }
}