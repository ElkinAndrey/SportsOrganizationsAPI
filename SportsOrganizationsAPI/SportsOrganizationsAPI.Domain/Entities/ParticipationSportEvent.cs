namespace SportsOrganizationsAPI.Domain.Entities
{
    /// <summary>
    /// Участие в спортивном мероприятии
    /// </summary>
    public class ParticipationSportEvent
    {
        /// <summary>
        /// Уникальный Id спортивного мероприятия
        /// </summary>
        public Guid SportEventId { get; set; }

        /// <summary>
        /// Уникальный Id человека
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Спортивное мероприятие
        /// </summary>
        public required SportEvent SportEvent { get; set; }

        /// <summary>
        /// Человек
        /// </summary>
        public required Person Person { get; set; }

        /// <summary>
        /// Роль в спортивном мероприятии
        /// </summary>
        public required SportEventRole SportEventRole { get; set; }

        /// <summary>
        /// Награда
        /// </summary>
        public Award? Award { get; set; }

    }
}
