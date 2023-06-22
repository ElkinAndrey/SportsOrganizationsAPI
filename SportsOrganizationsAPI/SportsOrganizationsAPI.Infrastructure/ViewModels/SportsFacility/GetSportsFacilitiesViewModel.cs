namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportsFacility
{
    /// <summary>
    /// int Start - начало отчета,
    /// int Length - длина среза,
    /// string Name - название спортивного сооружения,
    /// int CapacityPersonUpper - верхняя граница вместимости человек,
    /// int CapacityPersonLower - нижняя граница вместимости человек,
    /// Guid SportsFacilityTypeId - id типа спортивного сооружения,
    /// Guid CityId - id города,
    /// </summary>
    public record class GetSportsFacilitiesViewModel(
        int? Start,
        int? Length,
        string? Name,
        int? CapacityPersonUpper,
        int? CapacityPersonLower,
        Guid? SportsFacilityTypeId,
        Guid? CityId);
}
