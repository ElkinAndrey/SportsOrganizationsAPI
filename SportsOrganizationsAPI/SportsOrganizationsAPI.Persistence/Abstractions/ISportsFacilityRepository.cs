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

        /// <summary>
        /// Получить список спортивных сооружений
        /// </summary>
        /// <param name="start">Начало отчета</param>
        /// <param name="length">Длина среза</param>
        /// <param name="name">Часть названия</param>
        /// <param name="capacityPersonUpper">Нижняя граница вместимости человек</param>
        /// <param name="capacityPersonLower">Верхняя граница вместимости человек</param>
        /// <param name="sportsFacilityTypeId">Id типа спортивного сооружения</param>
        /// <param name="cityId">Id города</param>
        /// <returns>Список спортивных сооружений</returns>
        public Task<IEnumerable<SportsFacility>> GetSportsFacilitiesAsync(
            int start,
            int length,
            string? name = null,
            int? capacityPersonUpper = null,
            int? capacityPersonLower = null,
            Guid? sportsFacilityTypeId = null,
            Guid? cityId = null);

        /// <summary>
        /// Добавить новое спортивное сооружение
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="capacityPerson">Вместимость человек</param>
        /// <param name="sportsFacilityTypeId">Id типа спортивного сооружения</param>
        /// <param name="cityId">Id города</param>
        /// <returns></returns>
        public Task AddSportsFacilityAsync(
            Guid id,
            string name,
            int capacityPerson,
            Guid sportsFacilityTypeId,
            Guid cityId);

        /// <summary>
        /// Удалить спортивное сооружение
        /// </summary>
        /// <param name="id">Id спортивного сооружения</param>
        /// <returns></returns>
        public Task DeleteSportsFacilityByIdAsync(Guid id);

        /// <summary>
        /// Поменять параметры спортивного сооружения
        /// </summary>
        /// <remarks>
        /// В ID записывается уникальный Id спортивного сооружения 
        /// В остальные параметры вписываются новые значения. 
        /// Если значение не нужно менять, необходимо записать null.
        /// </remarks>
        /// <param name="id">Id сооружения, у которого будут изменены параметры</param>
        /// <param name="name">Новое название</param>
        /// <param name="capacityPerson">Новая вместимость</param>
        /// <param name="sportsFacilityTypeId">Новый тип спортивного сооружения</param>
        /// <param name="cityId">Новый город</param>
        /// <returns></returns>
        public Task ChangeSportsFacilityAsync(
            Guid id,
            string? name = null,
            int? capacityPerson = null,
            Guid? sportsFacilityTypeId = null,
            Guid? cityId = null);

        /// <summary>
        /// Получить спортивное сооружение по Id
        /// </summary>
        /// <param name="id">Id спортивного сооружения</param>
        /// <returns>Спортивное сооружение</returns>
        public Task<SportsFacility> GetSportsFacilityByIdAsync(Guid id);
    }
}
