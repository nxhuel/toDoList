using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_list_api.Models
{
    [Table("Login")]
    public class LoginModel
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The password length must be 8 or more")]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }



    }
}
