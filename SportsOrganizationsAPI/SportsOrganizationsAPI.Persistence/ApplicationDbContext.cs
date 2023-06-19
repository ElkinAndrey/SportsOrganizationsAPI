using Microsoft.EntityFrameworkCore;
using SportsOrganizationsAPI.Domain.Entities;

namespace SportsOrganizationsAPI.Persistence
{
    /// <summary>
    /// Контекст приложения
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        #region Данные

        /// <summary>
        /// Оценки
        /// </summary>
        public DbSet<Award> Awards { get; set; }

        /// <summary>
        /// Города
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Участия в спортивных мероприятиях
        /// </summary>
        public DbSet<ParticipationSportEvent> ParticipationSportEvents { get; set; }

        /// <summary>
        /// Люди
        /// </summary>
        public DbSet<Person> Persons { get; set; }
        
        /// <summary>
        /// Виды спорта
        /// </summary>
        public DbSet<Sport> Sports { get; set; }

        /// <summary>
        /// Спортивные мероприятия
        /// </summary>
        public DbSet<SportEvent> SportEvents { get; set; }

        /// <summary>
        /// Роли в спортивном мероприятии
        /// </summary>
        public DbSet<SportEventRole> SportEventRoles { get; set; }

        /// <summary>
        /// Спортивные сооружения
        /// </summary>
        public DbSet<SportsFacility> SportsFacilities { get; set; }

        /// <summary>
        /// Типы спортивных сооружений
        /// </summary>
        public DbSet<SportsFacilityType> SportsFacilityTypes { get; set; }

        #endregion

        /// <summary>
        /// Контектс базы данных
        /// </summary>
        /// <param name="options">Параметры</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Настройка базы данных
        /// </summary>
        /// <param name="modelBuilder">Параметры</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipationSportEvent>()
                .HasKey(p => new { p.PersonId, p.SportEventId });
        }
    }
}
