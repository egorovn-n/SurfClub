using System.ComponentModel.DataAnnotations;

namespace SurfClub.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Псевдоним")]
        public string UserName { get; set; }
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Запомнить пароль")]
        public bool RememberMe { get; set; }
    }
}
