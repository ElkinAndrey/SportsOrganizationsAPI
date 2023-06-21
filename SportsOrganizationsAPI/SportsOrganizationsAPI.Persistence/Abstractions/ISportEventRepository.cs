using SportsOrganizationsAPI.Domain.Entities;

namespace SportsOrganizationsAPI.Persistence.Abstractions
{
    /// <summary>
    /// Репозиторий, отвечающий за работу со спортивными мероприятиями
    /// </summary>
    public interface ISportEventRepository
    {
        /// <summary>
        /// Получить список наград
        /// </summary>
        /// <returns>Список наград</returns>
        public Task<IEnumerable<Award>> GetAwardsAsync();

        /// <summary>
        /// Добавить новую награду
        /// </summary>
        /// <param name="award">Награда</param>
        /// <returns></returns>
        public Task AddAwardAsync(Award award);

        /// <summary>
        /// Удалить награду по Id
        /// </summary>
        /// <param name="id">Id награды</param>
        /// <returns></returns>
        public Task DeleteAwardByIdAsync(Guid id);

        /// <summary>
        /// Изменить оценку
        /// </summary>
        /// <remarks>
        /// В ID записывается уникальный Id оценки, которую нужно
        /// изменить. В остальные параметры вписываются новые 
        /// значения. Если значение не нужно менять, необходимо 
        /// записать null.
        /// </remarks>
        /// <param name="award">Оценка</param>
        /// <returns></returns>
        public Task ChangeAwardAsync(Award award);
    }
}
