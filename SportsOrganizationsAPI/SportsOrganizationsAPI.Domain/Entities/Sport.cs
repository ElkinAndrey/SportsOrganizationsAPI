using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Вид спорта
    /// </summary>
    public class Sport
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid SportId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание вида спорта
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Участия в спортивных мероприятиях
        /// </summary>
        public List<ParticipationSportEvent> ParticipationSportEvents { get; set; } 
            = new List<ParticipationSportEvent>();

    }
}
