using SportsOrganizationsAPI.Persistence.Abstractions;


namespace SportsOrganizationsAPI.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий, отвечающий за работу со спортивными мероприятиями
    /// </summary>
    /// <remarks>
    /// Работает при помощи средств Entity Framework Core
    /// </remarks>
    public class EFSportEventRepository : ISportEventRepository
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Репозиторий, отвечающий за работу со спортивными мероприятиями
        /// </summary>
        /// <remarks>
        /// Работает при помощи средств Entity Framework Core
        /// </remarks>
        /// <param name="context">Контекст базы данных</param>
        public EFSportEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
