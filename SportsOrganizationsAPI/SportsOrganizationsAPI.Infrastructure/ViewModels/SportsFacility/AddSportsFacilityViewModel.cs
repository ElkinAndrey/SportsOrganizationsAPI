namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility
{
    /// <summary>
    /// string Name - название спортивного сооружения,
    /// int CapacityPerson - вместимость человек,
    /// Guid SportsFacilityTypeId - id типа спортивного сооружения,
    /// Guid CityId - id города,
    /// </summary>
    public record class AddSportsFacilityViewModel(
        string Name,
        int CapacityPerson,
        Guid SportsFacilityTypeId,
        Guid CityId);
}
