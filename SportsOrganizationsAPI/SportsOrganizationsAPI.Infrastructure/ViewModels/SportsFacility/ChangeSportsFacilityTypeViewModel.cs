namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility
{
    /// <summary>
    /// Guid Id - Id типа спортивного сооружения, 
    /// string Name - имя, 
    /// </summary>
    public record class ChangeSportsFacilityTypeViewModel(
        Guid Id,
        string? Name);
}
