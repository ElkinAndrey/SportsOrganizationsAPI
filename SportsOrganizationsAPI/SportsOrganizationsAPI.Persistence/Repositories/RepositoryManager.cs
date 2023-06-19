using SportsOrganizationsAPI.Persistence.Abstractions;

namespace SportsOrganizationsAPI.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий для работы с остальными репозиториями
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        /// <summary>
        /// Репозиторий, отвечающий за работу с простыми сущностями
        /// </summary>
        private readonly IHandBookRepository handBookRepository;

        /// <summary>
        /// Репозиторий для работы с остальными репозиториями
        /// </summary>
        public RepositoryManager(ApplicationDbContext context)
        {
            handBookRepository = new EFHandBookRepository(context);
        }

        /// <summary>
        /// Репозиторий, отвечающий за работу с простыми сущностями
        /// </summary>
        public IHandBookRepository HandBookRepository => handBookRepository;
    }
}
