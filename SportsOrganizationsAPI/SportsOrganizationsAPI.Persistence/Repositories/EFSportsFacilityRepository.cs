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

        public async Task AddSportsFacilityAsync(
            Guid id,
            string name,
            int capacityPerson,
            Guid sportsFacilityTypeId,
            Guid cityId)
        {
            var sportsFacilityType = await GetSportsFacilityTypeByIdAsync(sportsFacilityTypeId);
            var city = await GetCityByIdAsync(cityId);

            await _context.SportsFacilities.AddAsync(new SportsFacility
            {
                SportsFacilityId = id,
                Name = name,
                CapacityPerson = capacityPerson,
                SportsFacilityType = sportsFacilityType,
                City = city,
            });

            await _context.SaveChangesAsync();
        }

        public async Task ChangeCityAsync(City city)
        {
            var oldCity = await GetCityByIdAsync(city.CityId);

            if (city.Name is not null) 
                oldCity.Name = city.Name;
            if (city.Location is not null) 
                oldCity.Location = city.Location;

            await _context.SaveChangesAsync();
        }

        public async Task ChangeSportsFacilityAsync(
            Guid id,
            string? name = null,
            int? capacityPerson = null,
            Guid? sportsFacilityTypeId = null,
            Guid? cityId = null)
        {
            var oldSportsFacility = await GetSportsFacilityByIdAsync(id);

            if (name is not null)
                oldSportsFacility.Name = name;
            if (capacityPerson is not null)
                oldSportsFacility.CapacityPerson = capacityPerson;
            if (sportsFacilityTypeId is not null)
                oldSportsFacility.SportsFacilityType = await GetSportsFacilityTypeByIdAsync((Guid)sportsFacilityTypeId);
            if (cityId is not null)
                oldSportsFacility.City = await GetCityByIdAsync((Guid)cityId);

            await _context.SaveChangesAsync();
        }

        public async Task ChangeSportsFacilityTypeAsync(SportsFacilityType sportsFacilityType)
        {
            var oldSportsFacilityType = await GetSportsFacilityTypeByIdAsync(sportsFacilityType.SportsFacilityTypeId);

            if (sportsFacilityType.Name is not null) 
                oldSportsFacilityType.Name = sportsFacilityType.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCityByIdAsync(Guid id)
        {
            var city = await GetCityByIdAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получить тип спортивного сооружения по id
        /// </summary>
        /// <param name="id">Id типа спортивного сооружения</param>
        /// <returns>Тип спортивного сооружения</returns>
        public async Task<SportsFacilityType> GetSportsFacilityTypeByIdAsync(Guid id)
        {
            var sportsFacilityType = await _context.SportsFacilityTypes
                .Where(p => p.SportsFacilityTypeId == id)
                .FirstOrDefaultAsync();

            if (sportsFacilityType is null)
                throw new ElementNotFoundException(id.ToString());

            return sportsFacilityType;
        }

        /// <summary>
        /// Получить город по id
        /// </summary>
        /// <param name="id">Id города</param>
        /// <returns>Город</returns>
        public async Task<City> GetCityByIdAsync(Guid id)
        {
            var city = await _context.Cities
                .Where(p => p.CityId == id)
                .FirstOrDefaultAsync();

            if (city is null)
                throw new ElementNotFoundException(id.ToString());

            return city;
        }

        public async Task DeleteSportsFacilityByIdAsync(Guid id)
        {
            var sportsFacility = await GetSportsFacilityByIdAsync(id);
            _context.SportsFacilities.Remove(sportsFacility);
            await _context.SaveChangesAsync();
        }

        public async Task DeletSportsFacilitiesTypesByIdAsync(Guid id)
        {
            var sportsFacilityType = await GetSportsFacilityTypeByIdAsync(id);
            _context.SportsFacilityTypes.Remove(sportsFacilityType);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<IEnumerable<SportsFacility>> GetSportsFacilitiesAsync(
            int start,
            int length,
            string? name,
            int? capacityPersonUpper,
            int? capacityPersonLower,
            Guid? sportsFacilityTypeId,
            Guid? cityId)
        {
            var sportsFacilities = await _context.SportsFacilities
                .Include(s => s.SportsFacilityType)
                .Include(s => s.City)
                .Where(s => name == null || (s.Name ?? "").Contains(name))
                .Where(s => capacityPersonUpper == null || s.CapacityPerson <= capacityPersonUpper)
                .Where(s => capacityPersonLower == null || s.CapacityPerson >= capacityPersonLower)
                .Where(s => sportsFacilityTypeId == null ||
                    (s.SportsFacilityType ?? new SportsFacilityType { SportsFacilityTypeId = Guid.Empty})
                        .SportsFacilityTypeId == sportsFacilityTypeId)
                .Where(s => cityId == null || (s.City != null && (s.City.CityId) == cityId))
                .Skip(start)
                .Take(length)
                .ToListAsync();

            return sportsFacilities;
        }

        public async Task<IEnumerable<SportsFacilityType>> GetSportsFacilitiesTypesAsync()
        {
            return await _context.SportsFacilityTypes.ToListAsync();
        }

        public async Task<SportsFacility> GetSportsFacilityByIdAsync(Guid id)
        {
            var sportsFacility = await _context.SportsFacilities
                .Include(s => s.SportsFacilityType)
                .Include(s => s.City)
                .Where(s => s.SportsFacilityId == id)
                .FirstOrDefaultAsync();

            if (sportsFacility is null)
                throw new ElementNotFoundException(id.ToString());

            return sportsFacility;
        }
    }
}
