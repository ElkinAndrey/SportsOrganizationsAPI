using Microsoft.AspNetCore.Mvc;
using SportsOrganizationsAPI.Domain.Entities;
using SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility;
using SportsOrganizationsAPI.Persistence.Abstractions;

namespace SportsOrganizationsAPI.Presentation.Controllers
{
    /// <summary>
    /// ���������� ��� ������ �� ����������� ������������
    /// </summary>
    [ApiController]
    [Route("api/facility")]
    public class SportsFacilityController : ControllerBase
    {
        /// <summary>
        /// ���������
        /// </summary>
        private IRepositoryManager _repositoryManager;

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="repositoryManager">���������</param>
        public SportsFacilityController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        /// <summary>
        /// �������� ������ � ��������
        /// </summary>
        /// <remarks>
        /// ������
        /// [
        ///     {
        ///         "id": "196f31b4-e104-4a93-a91b-011eb1036b07",
        ///         "name": "1",
        ///         "location": "2",
        ///     }
        /// ]
        /// </remarks>
        /// <returns>������ � ��������</returns>
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
        /// �������� ����� �����
        /// </summary>
        /// <remarks>
        /// �������
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
        /// ������� ����� �� Id
        /// </summary>
        /// <param name="id">Id ���������� ������</param>
        [HttpDelete]
        [Route("cities/delete/{id}")]
        public async Task<IActionResult> DeleteCityByIdAsync(Guid id)
        {
            await _repositoryManager.SportsFacilityRepository.DeleteCityByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// �������� ��������� ������
        /// </summary>
        /// <remarks>
        /// �������
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
    }
}