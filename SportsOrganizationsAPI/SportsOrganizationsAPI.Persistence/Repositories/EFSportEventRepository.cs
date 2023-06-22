using Microsoft.EntityFrameworkCore;
using SportsOrganizationsAPI.Domain.Entities;
using SportsOrganizationsAPI.Persistence.Abstractions;
using SportsOrganizationsAPI.Persistence.Exceptions;

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

        /// <summary>
        /// Получить награду по Id
        /// </summary>
        /// <param name="id">Id награды</param>
        /// <returns>Награда</returns>
        public async Task<Award> GetAwardById(Guid id)
        {
            var award = await _context.Awards
                .Where(p => p.AwardId == id)
                .FirstOrDefaultAsync();

            if (award is null)
                throw new ElementNotFoundException(id.ToString());

            return award;
        }

        public async Task AddAwardAsync(Award award)
        {
            await _context.Awards.AddAsync(award);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeAwardAsync(Award award)
        {
            var oldAward = await GetAwardById(award.AwardId);

            if (award.Name is not null)
                oldAward.Name = award.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAwardByIdAsync(Guid id)
        {
            var award = await GetAwardById(id);
            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Award>> GetAwardsAsync()
        {
            return await _context.Awards.ToListAsync();
        }

        /// <summary>
        /// Получить вид спорта по Id
        /// </summary>
        /// <param name="id">Id вида спорта</param>
        /// <returns>Вид спорта</returns>
        public async Task<Sport> GetSportById(Guid id)
        {
            var sport = await _context.Sports
                .Where(p => p.SportId == id)
                .FirstOrDefaultAsync();

            if (sport is null)
                throw new ElementNotFoundException(id.ToString());

            return sport;
        }

        public async Task<IEnumerable<Sport>> GetSportsAsync()
        {
            return await _context.Sports.ToListAsync();
        }

        public async Task AddSportAsync(Sport sport)
        {
            await _context.Sports.AddAsync(sport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSportByIdAsync(Guid id)
        {
            var sport = await GetSportById(id);
            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeSportAsync(Sport sport)
        {
            var oldSport = await GetSportById(sport.SportId);

            if (sport.Name is not null)
                oldSport.Name = sport.Name;
            if (sport.Description is not null)
                oldSport.Description = sport.Description;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получить роль в спортивном мероприятии по Id
        /// </summary>
        /// <param name="id">Id вида спорта</param>
        /// <returns>Вид спорта</returns>
        public async Task<SportEventRole> GetSportEventRoleById(Guid id)
        {
            var sportEventRole = await _context.SportEventRoles
                .Where(p => p.SportEventRoleId == id)
                .FirstOrDefaultAsync();

            if (sportEventRole is null)
                throw new ElementNotFoundException(id.ToString());

            return sportEventRole;
        }

        public async Task<IEnumerable<SportEventRole>> GetSportEventRolesAsync()
        {
            return await _context.SportEventRoles.ToListAsync();
        }

        public async Task AddSportEventRoleAsync(SportEventRole sportEventRole)
        {
            await _context.SportEventRoles.AddAsync(sportEventRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSportEventRoleByIdAsync(Guid id)
        {
            var sportEventRole = await GetSportEventRoleById(id);
            _context.SportEventRoles.Remove(sportEventRole);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeSportEventRoleAsync(SportEventRole sportEventRole)
        {
            var oldSportEventRole = await GetSportEventRoleById(sportEventRole.SportEventRoleId);

            if (sportEventRole.Name is not null)
                oldSportEventRole.Name = sportEventRole.Name;
            if (sportEventRole.Description is not null)
                oldSportEventRole.Description = sportEventRole.Description;

            await _context.SaveChangesAsync();
        }
    }
}
