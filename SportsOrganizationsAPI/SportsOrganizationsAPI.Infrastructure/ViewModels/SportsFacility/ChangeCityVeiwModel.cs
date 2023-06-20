namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility
{
    /// <summary>
    /// Guid Id - id города, 
    /// string? Name - название, 
    /// string? Location - расположение, 
    /// </summary>
    public record class ChangeCityVeiwModel(
        Guid Id,
        string? Name,
        string? Location);
}
