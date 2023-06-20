using Microsoft.AspNetCore.Mvc;
using SportsOrganizationsAPI.Domain.Entities;
using SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility;
using SportsOrganizationsAPI.Persistence.Abstractions;

namespace SportsOrganizationsAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы со спортивными сооружениями
    /// </summary>
    [ApiController]
    [Route("api/facility")]
    public class SportsFacilityController : ControllerBase
    {
        /// <summary>
        /// Хранилище
        /// </summary>
        private IRepositoryManager _repositoryManager;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="repositoryManager">Хранилище</param>
        public SportsFacilityController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        /// <summary>
        /// Получить список с городами
        /// </summary>
        /// <remarks>
        /// Вернет
        /// [
        ///     {
        ///         "id": "196f31b4-e104-4a93-a91b-011eb1036b07",
        ///         "name": "1",
        ///         "location": "2",
        ///     }
        /// ]
        /// </remarks>
        /// <returns>Список с городами</returns>
        [HttpGet]
        [Route("cities")]
        public async Task<IActionResult> GetCitiesAsync()
        {
            var cities = (await _repositoryManager.SportsFacilityRepository.GetCitiesAsync())
                .Select(c => new 
                {
                    Id = c.CityId,
                    c.Name,
                    c.Location,
                });

            return Ok(cities);
        }

        /// <summary>
        /// Добавить новый город
        /// </summary>
        /// <remarks>
        /// Получит
        /// {
        ///     "name": "string",
        ///     "location": "string"
        /// }
        /// </remarks>
        [HttpPost]
        [Route("cities/add")]
        public async Task<IActionResult> AddCityAsync(AddCityViewModel model)
        {
            await _repositoryManager.SportsFacilityRepository.AddCityAsync(new City
            {
                CityId = Guid.NewGuid(),
                Name = model.Name,
                Location = model.Location,
            });

            return Ok();
        }

        /// <summary>
        /// Удалить город по Id
        /// </summary>
        /// <param name="id">Id удаляемого города</param>
        [HttpDelete]
        [Route("cities/delete/{id}")]
        public async Task<IActionResult> DeleteCityByIdAsync(Guid id)
        {
            await _repositoryManager.SportsFacilityRepository.DeleteCityByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// Изменить параметры города
        /// </summary>
        /// <remarks>
        /// Получит
        /// {
        ///     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///     "name": "string",
        ///     "location": "string"
        /// }
        /// </remarks>
        [HttpPut]
        [Route("cities/change")]
        public async Task<IActionResult> ChangeCityAsync(ChangeCityVeiwModel model)
        {
            await _repositoryManager.SportsFacilityRepository.ChangeCityAsync(new City
            {
                CityId = model.Id,
                Name = model.Name,
                Location = model.Location,
            });

            return Ok();
        }

        /// <summary>
        /// Получить список с типами спортивных сооружений
        /// </summary>
        /// <returns>Список с типами спортивных сооружений</returns>
        [HttpGet]
        [Route("sport")]
        public async Task<IActionResult> GetSportsFacilitiesTypesAsync()
        {
            var cities = (await _repositoryManager.SportsFacilityRepository.GetSportsFacilitiesTypesAsync())
                .Select(c => new
                {
                    Id = c.SportsFacilityTypeId,
                    c.Name,
                });

            return Ok(cities);
        }

        /// <summary>
        /// Добавить новый тип спортивных сооружений
        /// </summary>
        /// <param name="sportsFacilityType">Новый тип спортивных сооружений</param>
        /// <returns></returns>
        [HttpPost]
        [Route("sport/add")]
        public async Task<IActionResult> AddSportsFacilitiesTypesAsync(SportsFacilityType model)
        {
            await _repositoryManager.SportsFacilityRepository.AddSportsFacilitiesTypesAsync(new SportsFacilityType
            {
                SportsFacilityTypeId = Guid.NewGuid(),
                Name = model.Name,
            });

            return Ok();
        }

        /// <summary>
        /// Удалить тип спортивных сооружений
        /// </summary>
        /// <param name="id">Id типа спортивных сооружений</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("sport/delete/{id}")]
        public async Task<IActionResult> DeletSportsFacilitiesTypesByIdAsync(Guid id)
        {
            await _repositoryManager.SportsFacilityRepository.DeletSportsFacilitiesTypesByIdAsync(id);

            return Ok();
        }

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
        [HttpPut]
        [Route("sport/change")]
        public async Task<IActionResult> ChangeSportsFacilityTypeAsync(SportsFacilityType sportsFacilityType)
        {
            return Ok();
        }
    }
}