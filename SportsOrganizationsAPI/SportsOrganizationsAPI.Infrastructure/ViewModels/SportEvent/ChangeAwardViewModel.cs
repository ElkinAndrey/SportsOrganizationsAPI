﻿namespace SportsOrganizationsAPI.Infrastructure.ViewModels.SportEvent
{
    /// <summary>
    /// Guid Id - Id награды,
    /// string Name - имя, 
    /// </summary>
    public record class ChangeAwardViewModel(
        Guid Id,
        string? Name);
}
