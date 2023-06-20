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

        public async Task AddSportsFacilitiesTypesAsync(SportsFacilityType sportsFacilityType)
        {
            await _context.SportsFacilityTypes.AddAsync(sportsFacilityType);
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

        public async Task ChangeSportsFacilityTypeAsync(SportsFacilityType sportsFacilityType)
        {
            var oldSportsFacilityType = await _context.SportsFacilityTypes
                .Where(p => p.SportsFacilityTypeId == sportsFacilityType.SportsFacilityTypeId)
                .FirstOrDefaultAsync();

            if (oldSportsFacilityType is null)
                throw new ElementNotFoundException(sportsFacilityType.SportsFacilityTypeId.ToString());

            if (sportsFacilityType.Name is not null) 
                oldSportsFacilityType.Name = sportsFacilityType.Name;

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

        public async Task DeletSportsFacilitiesTypesByIdAsync(Guid id)
        {
            var sportsFacilityType = await _context.SportsFacilityTypes
                .Where(p => p.SportsFacilityTypeId == id)
                .FirstOrDefaultAsync();

            if (sportsFacilityType is null)
                throw new ElementNotFoundException(id.ToString());

            _context.SportsFacilityTypes.Remove(sportsFacilityType);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<IEnumerable<SportsFacilityType>> GetSportsFacilitiesTypesAsync()
        {
            return await _context.SportsFacilityTypes.ToListAsync();
        }
    }
}
