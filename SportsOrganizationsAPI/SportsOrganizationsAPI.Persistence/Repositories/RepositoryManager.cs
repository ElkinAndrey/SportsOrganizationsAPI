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
        /// Репозиторий для работы с остальными репозиториями
        /// </summary>
        public RepositoryManager(ApplicationDbContext context)
        {
            personRepository = new EFPersonRepository(context);
            sportEventRepository = new EFSportEventRepository(context);
        }

        /// <summary>
        /// Репозиторий, отвечающий за работу с людьми
        /// </summary>
        public IPersonRepository PersonRepository => personRepository;

        /// <summary>
        /// Репозиторий, отвечающий за работу со спортивными мероприятиями
        /// </summary>
        public ISportEventRepository SportEventRepository => sportEventRepository;
    }
}
