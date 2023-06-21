namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportEvent
{
    /// <summary>
    /// string Name - имя, 
    /// string Description - описание вида спорта, 
    /// </summary>
    public record class AddSportViewModel(
        string Name,
        string Description);
}
