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

        /// <summary>
        /// �������� ������ � ������ ���������� ����������
        /// </summary>
        /// <returns>������ � ������ ���������� ����������</returns>
        [HttpGet]
        [Route("type")]
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
        /// �������� ����� ��� ���������� ����������
        /// </summary>
        /// <param name="sportsFacilityType">����� ��� ���������� ����������</param>
        /// <returns></returns>
        [HttpPost]
        [Route("type/add")]
        public async Task<IActionResult> AddSportsFacilitiesTypesAsync(AddSportsFacilitiesTypesViewModel model)
        {
            await _repositoryManager.SportsFacilityRepository.AddSportsFacilitiesTypesAsync(new SportsFacilityType
            {
                SportsFacilityTypeId = Guid.NewGuid(),
                Name = model.Name,
            });

            return Ok();
        }

        /// <summary>
        /// ������� ��� ���������� ����������
        /// </summary>
        /// <param name="id">Id ���� ���������� ����������</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("type/delete/{id}")]
        public async Task<IActionResult> DeletSportsFacilitiesTypesByIdAsync(Guid id)
        {
            await _repositoryManager.SportsFacilityRepository.DeletSportsFacilitiesTypesByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// �������� ��� ����������� ����������
        /// </summary>
        /// <remarks>
        /// � ID ������������ ���������� Id ���� ����������� ����������,
        /// ������� ����� ��������. � ��������� ��������� ����������� 
        /// ����� ��������. ���� �������� �� ����� ������, ���������� 
        /// �������� null.
        /// </remarks>
        /// <param name="sportsFacilityType">��� ����������� ����������</param>
        /// <returns></returns>
        [HttpPut]
        [Route("type/change")]
        public async Task<IActionResult> ChangeSportsFacilityTypeAsync(SportsFacilityType sportsFacilityType)
        {
            return Ok();
        }

        /// <summary>
        /// �������� ������ ���������� ����������
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetSportsFacilitiesAsync(
            GetSportsFacilitiesViewModel model)
        {
            var sportsFacilities = (await _repositoryManager.SportsFacilityRepository
                .GetSportsFacilitiesAsync(
                    start: model.Start ?? 0,
                    length: model.Length ?? int.MaxValue,
                    name: model.Name,
                    capacityPersonLower: model.CapacityPersonLower,
                    capacityPersonUpper: model.CapacityPersonUpper,
                    cityId: model.CityId,
                    sportsFacilityTypeId: model.SportsFacilityTypeId))
                .Select(s => new
                {
                    Id = s.SportsFacilityId,
                    s.Name,
                    s.CapacityPerson,
                    Type = s.SportsFacilityType?.Name,
                    City = s.City is null ? null : new
                    {
                        Id = s.City.CityId,
                        s.City.Name,
                        s.City.Location,
                    },
                });

            return Ok(sportsFacilities);
        }

        /// <summary>
        /// �������� ���������� ���������� �� Id
        /// </summary>
        /// <remarks>
        /// � ���������� ���������� ����� ������� ������ �� ����������� �������������
        /// </remarks>
        /// <returns>���������� ����������</returns>
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetSportsFacilityByIdAsync(Guid id)
        {
            var sportsFacility = await _repositoryManager.SportsFacilityRepository
                .GetSportsFacilityByIdAsync(id);

            var viewModel = new
            {
                Id = sportsFacility.SportsFacilityId,
                sportsFacility.Name,
                sportsFacility.CapacityPerson,
                Type = sportsFacility.SportsFacilityType?.Name,
                City = sportsFacility.City is null ? null : new
                {
                    Id = sportsFacility.City.CityId,
                    sportsFacility.City.Name,
                    sportsFacility.City.Location,
                },
            };

            return Ok(viewModel);
        }

        /// <summary>
        /// �������� ����� ���������� ����������
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSportsFacilityAsync(
            AddSportsFacilityViewModel model)
        {
            await _repositoryManager.SportsFacilityRepository.AddSportsFacilityAsync(
                id: Guid.NewGuid(),
                name: model.Name,
                capacityPerson: model.CapacityPerson,
                sportsFacilityTypeId: model.SportsFacilityTypeId,
                cityId: model.CityId);
            
            return Ok();
        }

        /// <summary>
        /// ������� ���������� ����������
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteSportsFacilityByIdAsync(Guid id)
        {
            await _repositoryManager.SportsFacilityRepository
                .DeleteSportsFacilityByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// �������� ��������� ����������� ����������
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPut]
        [Route("change")]
        public async Task<IActionResult> ChangeSportsFacilityAsync(
            ChangeSportsFacilityViewModel model)
        {
            await _repositoryManager.SportsFacilityRepository.ChangeSportsFacilityAsync(
                id: model.Id,
                name: model.Name,
                capacityPerson: model.CapacityPerson,
                cityId: model.CityId,
                sportsFacilityTypeId: model.SportsFacilityTypeId);

            return Ok();
        }
    }
}