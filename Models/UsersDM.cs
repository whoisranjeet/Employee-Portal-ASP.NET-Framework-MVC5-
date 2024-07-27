using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class UsersDM
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "ID cannot be empty !!!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username cannot be empty.")]
        [MinLength(5, ErrorMessage = "Username should be atleast 5 characters long.")]
        [MaxLength(10, ErrorMessage = "Username cannot be more than 10 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty.")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password should be atleast 5 characters long.")]
        [MaxLength(10, ErrorMessage = "Password cannot be more than 10 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm password.")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Minimum 5 characters is required.")]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters is allowed.")]
        public string ConfirmPassword { get; set; }
        public int? Roleid { get; set; }
        public RolesDM RolesDM { get; set; }
    }
}