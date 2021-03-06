using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfClub.Models
{
    /// <summary>
    /// Запись в ленте
    /// </summary>
    public class Post
    {
        /// <summary>
        /// ИД записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текст записи
        /// </summary>
        [MaxLength(4095)]
        [Display(Name = "Введите текст")]
        public string? Text { get; set; }

        /// <summary>
        /// Изображение
        /// </summary>
        [Display(Name = "Прикрепить изображение")]
        public Guid? Photo { get; set; }

        /// <summary>
        /// ИД пользователя-автора записи
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Автор записи
        /// </summary>
        [ForeignKey(nameof(AuthorId))]
        public virtual User Author { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
