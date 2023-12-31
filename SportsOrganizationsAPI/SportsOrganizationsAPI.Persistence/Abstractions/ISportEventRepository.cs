﻿using SportsOrganizationsAPI.Domain.Entities;

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

        /// <summary>
        /// Получить виды спорта
        /// </summary>
        /// <returns>Список видов спорта</returns>
        public Task<IEnumerable<Sport>> GetSportsAsync();

        /// <summary>
        /// Добавить новый вид спорта
        /// </summary>
        /// <param name="sport">Новый вид спорта</param>
        /// <returns></returns>
        public Task AddSportAsync(Sport sport);

        /// <summary>
        /// Удалить вид спорта по Id
        /// </summary>
        /// <param name="id">Id вида спорта</param>
        /// <returns></returns>
        public Task DeleteSportByIdAsync(Guid id);

        /// <summary>
        /// Изменить вид спорта
        /// </summary>
        /// <remarks>
        /// В ID записывается уникальный Id вида спорта, который нужно
        /// изменить. В остальные параметры вписываются новые 
        /// значения. Если значение не нужно менять, необходимо 
        /// записать null.
        /// </remarks>
        /// <param name="sport">Вид спорта</param>
        /// <returns></returns>
        public Task ChangeSportAsync(Sport sport);

        /// <summary>
        /// Получить список ролей в спортивном мероприятии
        /// </summary>
        /// <returns>Список с ролями в спортивном мероприятии</returns>
        public Task<IEnumerable<SportEventRole>> GetSportEventRolesAsync();

        /// <summary>
        /// Добавить новую роль в спортивное мероприятие
        /// </summary>
        /// <param name="sportEventRole">Новая роль в спортивном мероприятии</param>
        /// <returns></returns>
        public Task AddSportEventRoleAsync(SportEventRole sportEventRole);

        /// <summary>
        /// Удалить роль в спортивном мероприятии по Id 
        /// </summary>
        /// <param name="id">Id удаляемой роли</param>
        /// <returns></returns>
        public Task DeleteSportEventRoleByIdAsync(Guid id);

        /// <summary>
        /// Изменить роль в спортивном мероприятии
        /// </summary>
        /// <remarks>
        /// В ID записывается уникальный Id роли в спортивном 
        /// мероприятии, которую нужно изменить. В остальные параметры 
        /// вписываются новые значения. Если значение не нужно менять, 
        /// необходимо записать null.
        /// </remarks>
        /// <param name="sportEventRole">Роль в спортивном мероприятии</param>
        /// <returns></returns>
        public Task ChangeSportEventRoleAsync(SportEventRole sportEventRole);
    }
}
