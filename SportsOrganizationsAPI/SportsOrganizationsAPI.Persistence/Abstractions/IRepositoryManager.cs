namespace SportsOrganizationsAPI.Persistence.Abstractions
{
    /// <summary>
    /// Менеджер репозиториев
    /// </summary>
    public interface IRepositoryManager
    {
        /// <summary>
        /// Репозиторий, отвечающий за работу с простыми сущностями
        /// </summary>
        IHandBookRepository HandBookRepository { get; }
    }
}
