using System.ComponentModel.DataAnnotations;

namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Спортивное мероприятие
    /// </summary>
    public class SportEvent
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        [Key]
        public Guid SportEventId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание спортивного мероприятия
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Начало соревнования
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Окончание соревнования
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Вид спорта
        /// </summary>
        public Sport? Sport { get; set; }

        /// <summary>
        /// Спортивное сооружение
        /// </summary>
        public SportsFacility? SportsFacility { get; set; }

        /// <summary>
        /// Участники спортивных мероприятий
        /// </summary>
        public List<ParticipationSportEvent> ParticipationSportEvents { get; set; }
            = new List<ParticipationSportEvent>();
    }
}
