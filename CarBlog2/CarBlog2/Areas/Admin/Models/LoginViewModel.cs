using System.ComponentModel.DataAnnotations;

namespace CarBlog2.Areas.Admin.Models
{
    public class LoginViewModel
    {
        [Key]
        [MaxLength(50)]
        [Required(ErrorMessage = "Vui long nhap Email")]
        [Display(Name = "Dia chi Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Vui long nhap Email")]
        public string Email { get; set; }

        [Display(Name = "Mat Khau")]
        [Required(ErrorMessage = "Vui long nhap mat khau")]
        [MaxLength(30, ErrorMessage = "Mat khau chi duoc su dung 30 ky tu")]
        public string Password { get; set; }

    }
}
