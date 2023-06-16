using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Спортивное сооружение
    /// </summary>
    public class SportsFacility
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid SportsFacilityId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Вместимость человек
        /// </summary>
        public int? CapacityPerson { get; set; }

        /// <summary>
        /// Тип спортивного сооружения
        /// </summary>
        public SportsFacilityType? SportsFacilityType { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public City? City { get; set; }

        /// <summary>
        /// Спортивные мероприятия в этом городе
        /// </summary>
        public List<SportEvent> SportEvents { get; set; } = new List<SportEvent>();
    }
}
