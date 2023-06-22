namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportEvent
{
    /// <summary>
    /// string Name - имя, 
    /// string Description - описание вида спорта, 
    /// </summary>
    public record class AddSportEventRoleViewModel(
        string Name,
        string Description);
}
