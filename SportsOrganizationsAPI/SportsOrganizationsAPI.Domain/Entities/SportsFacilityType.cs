using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Тип спортивного сооружения
    /// </summary>
    public class SportsFacilityType
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid SportsFacilityTypeId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }
    }
}
