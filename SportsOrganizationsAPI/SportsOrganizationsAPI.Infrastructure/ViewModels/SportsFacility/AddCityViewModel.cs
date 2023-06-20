namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility
{
    /// <summary>
    /// string Name - имя, 
    /// string Location - расположение, 
    /// </summary>
    public record class AddCityViewModel(
        string Name,
        string Location);
}
