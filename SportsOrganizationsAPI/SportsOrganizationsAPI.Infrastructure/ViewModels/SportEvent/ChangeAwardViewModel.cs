namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportEvent
{
    /// <summary>
    /// Guid Id - Id награды,
    /// string Name - имя, 
    /// </summary>
    /// <param name="Name"></param>
    public record class ChangeAwardViewModel(
        Guid Id,
        string Name);
}
