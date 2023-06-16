using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid CityId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Расположение
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Спортивные сооружения в городе
        /// </summary>
        public List<SportsFacility> SportsFacilities { get; set; } = new List<SportsFacility>();
    }
}
