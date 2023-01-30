using System.ComponentModel.DataAnnotations;

namespace CarBlog2.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    {
        [Key]
        public int AccountId { get; set; }
        [Display(Name = "Mat khau hien tai")]
        public string PasswordNow { get; set; }
        [Display(Name = "Mat khau hien tai")]
        [Required(ErrorMessage = "Vui long nhap mat khau")]
        [MinLength(5, ErrorMessage = "Ban can dat mat khau toi thieu 5 ky tu")]
        public string Password { get; set; }
        [MinLength(5, ErrorMessage = "Ban can cai dat mat khau toi thieu 5 ky tu")]
        [Display(Name = "Nhap lai mat khau moi")]
        [Compare("Password", ErrorMessage = "mat khau khong giong nhau")]
        public string ConfirmPassword { get; set; }
    }
}
