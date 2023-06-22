namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility
{
    /// <summary>
    /// Guid Id - id спортивного сооружения,
    /// string Name - новое название,
    /// int CapacityPerson - вместимость человек,
    /// Guid SportsFacilityTypeId - id типа спортивного сооружения,
    /// Guid CityId - id города,
    /// </summary>
    public record class ChangeSportsFacilityViewModel(
        Guid Id,
        string? Name,
        int? CapacityPerson,
        Guid? SportsFacilityTypeId,
        Guid? CityId);
}
