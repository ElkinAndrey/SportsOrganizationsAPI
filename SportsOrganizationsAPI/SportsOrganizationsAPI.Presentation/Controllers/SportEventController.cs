using Microsoft.AspNetCore.Mvc;
using SportsOrganizationsAPI.Domain.Entities;
using SportsOrganizationsAPI.Infrastructure.ViewModels.SportEvent;
using SportsOrganizationsAPI.Persistence.Abstractions;

namespace SportsOrganizationsAPI.Presentation.Controllers
{
    /// <summary>
    /// Контроллер для работы со спортивными мероприятиями
    /// </summary>
    [ApiController]
    [Route("api/event")]
    public class SportEventController : ControllerBase
    {
        /// <summary>
        /// Хранилище
        /// </summary>
        private IRepositoryManager _repositoryManager;

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="repositoryManager">Хранилище</param>
        public SportEventController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        /// <summary>
        /// Получить список наград
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>Список наград</returns>
        [HttpGet]
        [Route("awards")]
        public async Task<IActionResult> GetAwardsAsync()
        {
            var awards = (await _repositoryManager.SportEventRepository
                .GetAwardsAsync())
                .Select(a => new
                {
                    Id = a.AwardId,
                    a.Name,
                });

            return Ok(awards);
        }

        /// <summary>
        /// Добавить новую награду
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPost]
        [Route("awards/add")]
        public async Task<IActionResult> AddAwardAsync(AddAwardViewModel model)
        {
            await _repositoryManager.SportEventRepository
                .AddAwardAsync(new Award
                {
                    AwardId = Guid.NewGuid(),
                    Name = model.Name,
                });

            return Ok();
        }

        /// <summary>
        /// Удалить награду по Id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="id">Id награды</param>
        [HttpDelete]
        [Route("awards/delete/{id}")]
        public async Task<IActionResult> DeleteAwardByIdAsync(Guid id)
        {
            await _repositoryManager.SportEventRepository
                .DeleteAwardByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// Изменить оценку
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPut]
        [Route("awards/change")]
        public async Task<IActionResult> ChangeAwardAsync(ChangeAwardViewModel model)
        {
            await _repositoryManager.SportEventRepository
                .ChangeAwardAsync(new Award
                {
                    AwardId = model.Id,
                    Name = model.Name,
                });

            return Ok();
        }

        /// <summary>
        /// Получить виды спорта
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>Список видов спорта</returns>
        [HttpGet]
        [Route("sports")]
        public async Task<IActionResult> GetSportsAsync()
        {
            var sports = (await _repositoryManager.SportEventRepository
                .GetSportsAsync())
                .Select(a => new
                {
                    Id = a.SportId,
                    a.Name,
                    a.Description,
                });

            return Ok(sports);
        }

        /// <summary>
        /// Добавить новый вид спорта
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPost]
        [Route("sports/add")]
        public async Task<IActionResult> AddSportAsync(AddSportViewModel model)
        {
            await _repositoryManager.SportEventRepository
                .AddSportAsync(new Sport
                {
                    SportId = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                });

            return Ok();
        }

        /// <summary>
        /// Удалить вид спорта по Id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpDelete]
        [Route("sports/delete/{id}")]
        public async Task<IActionResult> DeleteSportByIdAsync(Guid id)
        {
            await _repositoryManager.SportEventRepository
                .DeleteSportByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// Изменить вид спорта
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPut]
        [Route("sports/change")]
        public async Task<IActionResult> ChangeSportAsync(ChangeSportViewModel model)
        {
            await _repositoryManager.SportEventRepository
                .ChangeSportAsync(new Sport
                {
                    SportId = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                });

            return Ok();
        }


        /// <summary>
        /// Получить список ролей в спортивном мероприятии
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>Список с ролями в спортивном мероприятии</returns>
        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetSportEventRolesAsync()
        {
            var sportEventRoles = (await _repositoryManager.SportEventRepository
                .GetSportEventRolesAsync())
                .Select(a => new
                {
                    Id = a.SportEventRoleId,
                    a.Name,
                    a.Description,
                });

            return Ok(sportEventRoles);
        }

        /// <summary>
        /// Добавить новую роль в спортивное мероприятие
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPost]
        [Route("roles/add")]
        public async Task<IActionResult> AddSportEventRoleAsync(AddSportEventRoleViewModel model)
        {
            await _repositoryManager.SportEventRepository
                .AddSportEventRoleAsync(new SportEventRole
                {
                    SportEventRoleId = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                });

            return Ok();
        }

        /// <summary>
        /// Удалить роль в спортивном мероприятии по Id 
        /// </summary>
        /// <param name="id">Id удаляемой роли</param>
        [HttpDelete]
        [Route("roles/delete/{id}")]
        public async Task<IActionResult> DeleteSportEventRoleByIdAsync(Guid id)
        {
            await _repositoryManager.SportEventRepository
                .DeleteSportEventRoleByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// Изменить роль в спортивном мероприятии
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPut]
        [Route("roles/change")]
        public async Task<IActionResult> ChangeSportEventRoleAsync(ChangeSportEventRoleViewModel model)
        {
            await _repositoryManager.SportEventRepository
                .ChangeSportEventRoleAsync(new SportEventRole
                {
                    SportEventRoleId = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                });

            return Ok();
        }
    }
}
