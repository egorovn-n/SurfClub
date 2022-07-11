using System.ComponentModel.DataAnnotations;

namespace SurfClub.Models
{
    public class RegistrationViewModel
    {
        [Display(Name = "Псевдоним*")]
        public string UserName { get; set; }

        [Display(Name = "Почта*")]
        public string Email { get; set; }

        [Display(Name = "Пароль*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтвердите пароль*")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }

        [Display(Name = "Имя")]
        public string? FirstName { get; set; }

        [Display(Name = "Выберите фото")]
        public Guid? SelectPhoto { get; set; }

        [Display(Name = "Контактная информация")]
        public string? ContactInfo { get; set; }

        [Display(Name = "О себе")]
        public string? About { get; set; }

        [Display(Name = "Достижения")]
        public string? Achievements { get; set; }
    }
}
