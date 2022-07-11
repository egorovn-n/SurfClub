using System.ComponentModel.DataAnnotations;

namespace SurfClub.Models
{
    public class RegistrationViewModel
    {
        [Required, MinLength(3, ErrorMessage = "Псевдоним должен содержать более 3 символов"), MaxLength(20)]
        [Display(Name = "Псевдоним*")]
        public string UserName { get; set; }

        [Required, MaxLength(31)]
        [Display(Name = "Почта*")]
        public string Email { get; set; }

        [Required, MinLength(6, ErrorMessage = "Пароль должен содержать более 3 символов"), MaxLength(20)]
        [Display(Name = "Пароль*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MinLength(6, ErrorMessage = "Пароль должен содержать более 3 символов"), MaxLength(20)]
        [Display(Name = "Подтвердите пароль*")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }

        [Display(Name = "Имя")]
        public string? FirstName { get; set; }

        [Display(Name = "Выберите фото")]
        public Guid? SelectPhoto { get; set; }

        [MaxLength(255)]
        [Display(Name = "Контактная информация")]
        public string? ContactInfo { get; set; }

        [MaxLength(255)]
        [Display(Name = "О себе")]
        public string? About { get; set; }

        [MaxLength(255)]
        [Display(Name = "Достижения")]
        public string? Achievements { get; set; }
    }
}
