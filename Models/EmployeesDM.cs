using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class EmployeesDM
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "ID cannot be empty !!!")]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        [MaxLength(20, ErrorMessage = " Maximum 20 character is allowed")]
        public string Firstname { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(20, ErrorMessage = " Maximum 20 character is allowed")]
        public string Lastname { get; set; }

        [DisplayName("Mobile Number")]
        [MaxLength(10, ErrorMessage = "Maximum length is 10")]
        public string Mobile { get; set; }

        [DisplayName("Email Address")]
        [MaxLength(30, ErrorMessage = " Maximum 30 character is allowed")]
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }

        [MaxLength(30, ErrorMessage = " Maximum 30 character is allowed")]
        public string Address { get; set; }

        [MaxLength(30, ErrorMessage = " Maximum 30 character is allowed")]
        public string Department { get; set; }
        public int? Userid { get; set; }
        public UsersDM UsersDM { get; set; }
    }
}