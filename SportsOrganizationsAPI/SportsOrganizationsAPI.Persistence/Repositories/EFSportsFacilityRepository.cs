using Microsoft.EntityFrameworkCore;
using SportsOrganizationsAPI.Domain.Entities;
using SportsOrganizationsAPI.Persistence.Abstractions;
using SportsOrganizationsAPI.Persistence.Exceptions;

namespace SportsOrganizationsAPI.Persistence.Repositories
{
    /// <summary>
    /// Репозиторий, отвечающий за работу со спортивными сооружениями
    /// </summary>
    /// <remarks>
    /// Работает при помощи средств Entity Framework Core
    /// </remarks>
    public class EFSportsFacilityRepository : ISportsFacilityRepository
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Репозиторий, отвечающий за работу со спортивными сооружениями
        /// </summary>
        /// <remarks>
        /// Работает при помощи средств Entity Framework Core
        /// </remarks>
        /// <param name="context">Контекст базы данных</param>
        public EFSportsFacilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeCityAsync(City city)
        {
            var oldCity = await _context.Cities
                .Where(p => p.CityId == city.CityId)
                .FirstOrDefaultAsync();

            if (oldCity is null)
                throw new ElementNotFoundException(city.CityId.ToString());

            if (city.Name is not null) 
                oldCity.Name = city.Name;
            if (city.Location is not null) 
                oldCity.Location = city.Location;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCityByIdAsync(Guid id)
        {
            var city = await _context.Cities
                .Where(p => p.CityId == id)
                .FirstOrDefaultAsync();

            if (city is null)
                throw new ElementNotFoundException(id.ToString());

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
