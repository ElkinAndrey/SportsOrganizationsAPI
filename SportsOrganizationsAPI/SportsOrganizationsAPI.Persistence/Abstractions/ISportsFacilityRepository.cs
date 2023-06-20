using SportsOrganizationsAPI.Domain.Entities;

namespace SportsOrganizationsAPI.Persistence.Abstractions
{
    /// <summary>
    /// Репозиторий, отвечающий за работу со спортивными сооружениями
    /// </summary>
    public interface ISportsFacilityRepository
    {
        /// <summary>
        /// Получить список с городами
        /// </summary>
        /// <returns>Список с городами</returns>
        public Task<IEnumerable<City>> GetCitiesAsync();

        /// <summary>
        /// Добавить новый город
        /// </summary>
        /// <param name="city">Новый город</param>
        /// <returns></returns>
        public Task AddCityAsync(City city);

        /// <summary>
        /// Удалить город по Id
        /// </summary>
        /// <param name="id">Id удаляемого города</param>
        /// <returns></returns>
        public Task DeleteCityByIdAsync(Guid id);

        /// <summary>
        /// Изменить параметры города
        /// </summary>
        /// <remarks>
        /// В ID записывается уникальный Id города, которую нужно
        /// изменить. В остальные параметры вписываются новые 
        /// значения. Если значение не нужно менять, необходимо 
        /// записать null.
        /// </remarks>
        /// <param name="city">Город</param>
        /// <returns></returns>
        public Task ChangeCityAsync(City city);

        /// <summary>
        /// Получить список с типами спортивных сооружений
        /// </summary>
        /// <returns>Список с типами спортивных сооружений</returns>
        public Task<IEnumerable<SportsFacilityType>> GetSportsFacilitiesTypesAsync();

        /// <summary>
        /// Добавить новый тип спортивных сооружений
        /// </summary>
        /// <param name="sportsFacilityType">Новый тип спортивных сооружений</param>
        /// <returns></returns>
        public Task AddSportsFacilitiesTypesAsync(SportsFacilityType sportsFacilityType);

        /// <summary>
        /// Удалить тип спортивных сооружений
        /// </summary>
        /// <param name="id">Id типа спортивных сооружений</param>
        /// <returns></returns>
        public Task DeletSportsFacilitiesTypesByIdAsync(Guid id);

        /// <summary>
        /// Изменить тип спортивного сооружения
        /// </summary>
        /// <remarks>
        /// В ID записывается уникальный Id типа спортивного сооружения,
        /// который нужно изменить. В остальные параметры вписываются 
        /// новые значения. Если значение не нужно менять, необходимо 
        /// записать null.
        /// </remarks>
        /// <param name="sportsFacilityType">Тип спортивного сооружения</param>
        /// <returns></returns>
        public Task ChangeSportsFacilityTypeAsync(SportsFacilityType sportsFacilityType);
    }
}
