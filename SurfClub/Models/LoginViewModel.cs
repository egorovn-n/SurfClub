using System.ComponentModel.DataAnnotations;

namespace SurfClub.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Псевдоним")]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        public string Password { get; set; }
        [Display(Name = "Запомнить пароль")]
        public bool RememberMe { get; set; }

        public  LoginViewModel()
        {
            RememberMe = true;
        }
    }
}
