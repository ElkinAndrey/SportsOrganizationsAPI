using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Роль в спортивном мероприятии
    /// </summary>
    public class SportEventRole
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid SportEventRoleId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание роли
        /// </summary>
        public string? Description { get; set; }
    }
}
