using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid PersonId { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime? DateBirth { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string? Email { get; set; }
    }
}
