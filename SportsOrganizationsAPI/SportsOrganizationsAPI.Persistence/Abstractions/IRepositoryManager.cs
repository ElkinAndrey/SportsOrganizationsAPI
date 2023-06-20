namespace SportsOrganizationsAPI.Persistence.Abstractions
{
    /// <summary>
    /// Менеджер репозиториев
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Репозиторий, отвечающий за работу с простыми сущностями
        /// </summary>
        IPersonRepository PersonRepository { get; }

        /// <summary>
        /// Репозиторий, отвечающий за работу со спортивными мероприятиями
        /// </summary>
        ISportEventRepository SportEventRepository { get; }

        /// <summary>
        /// Репозиторий, отвечающий за работу со спортивными сооружениями
        /// </summary>
        ISportsFacilityRepository SportsFacilityRepository { get; }
    }
}
