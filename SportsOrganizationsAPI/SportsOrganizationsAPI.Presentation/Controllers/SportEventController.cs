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
    }
}
