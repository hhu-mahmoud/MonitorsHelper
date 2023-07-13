namespace Logic.Shared.Repositories.BaseRepository;

using System.Drawing;

using Enumerations;

using Interfaces;

using Models;

internal abstract class BaseDisplayRepository : IDisplayRepository
{
    #region explicit interfaces
    /// <inheritdoc cref="IDisplayRepository"/>
    public abstract IEnumerable<DisplayModel> GetActiveDisplays();

    /// <inheritdoc cref="IDisplayRepository"/>
    public abstract IEnumerable<DisplayModel> GetAllDisplays();

    /// <inheritdoc cref="IDisplayRepository"/>
    public DisplayModel GetDisplayById(int id)
    {
        return (GetAllDisplays().FirstOrDefault(x => x.Id.Equals(id)) ?? null)!;
    }

    /// <inheritdoc cref="IDisplayRepository"/>
    public DisplayModel GetPrimaryDisplay()
    {
        return GetActiveDisplays().First(x => x.IsPrimary);
    }

    /// <inheritdoc cref="IDisplayRepository"/>
    public abstract bool SetResolution(DisplayModel display, Size newResolution);

    /// <inheritdoc cref="IDisplayRepository"/>
    public abstract bool SetRotation(DisplayModel display, DisplayRotation rotation);

    /// <inheritdoc cref="IDisplayRepository"/>
    public abstract bool TurnOff(DisplayModel display);

    /// <inheritdoc cref="IDisplayRepository"/>
    public abstract bool TurnOn(DisplayModel display);

    #endregion
}