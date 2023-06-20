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
        /// Репозиторий для работы с остальными репозиториями
        /// </summary>
        public RepositoryManager(ApplicationDbContext context)
        {
            personRepository = new EFPersonRepository(context);
        }

        /// <summary>
        /// Репозиторий, отвечающий за работу с людьми
        /// </summary>
        public IPersonRepository PersonRepository => personRepository;
    }
}
