namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportEvent
{
    /// <summary>
    /// Guid Id - Id награды,
    /// string Name - имя, 
    /// string Description - описание вида спорта, 
    /// </summary>
    public record class ChangeSportViewModel(
        Guid Id,
        string? Name,
        string? Description);
}
