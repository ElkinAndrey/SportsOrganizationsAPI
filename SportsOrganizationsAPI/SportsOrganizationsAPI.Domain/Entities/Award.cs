using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Награда
    /// </summary>
    public class Award
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid AwardId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }
    }
}
