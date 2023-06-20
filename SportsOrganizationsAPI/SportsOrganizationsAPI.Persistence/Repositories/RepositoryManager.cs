using SportsOrganizationsAPI.Persistence.Abstractions;

namespace SportsOrganizationsAPI.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для работы с остальными репозиториями
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// Репозиторий, отвечающий за работу с людьми
        /// </summary>
        private readonly IPersonRepository personRepository;

        /// <summary>
        /// Репозиторий, отвечающий за работу со спортивными мероприятиями
        /// </summary>
        private readonly ISportEventRepository sportEventRepository;

        /// <summary>
        /// Репозиторий, отвечающий за работу со спортивными сооружениями
        /// </summary>
        private readonly ISportsFacilityRepository sportsFacilityRepository;

        /// <summary>
        /// Репозиторий для работы с остальными репозиториями
        /// </summary>
        public RepositoryManager(ApplicationDbContext context)
        {
            personRepository = new EFPersonRepository(context);
            sportEventRepository = new EFSportEventRepository(context);
            sportsFacilityRepository = new EFSportsFacilityRepository(context);
        }

        public IPersonRepository PersonRepository => personRepository;

        public ISportEventRepository SportEventRepository => sportEventRepository;

        public ISportsFacilityRepository SportsFacilityRepository => sportsFacilityRepository;
    }
}
