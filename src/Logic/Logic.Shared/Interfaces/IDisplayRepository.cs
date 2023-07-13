namespace Logic.Shared.Interfaces;

using System.Drawing;

using Enumerations;

using Models;

/// <summary>
/// Each display model implementation is abstracted away with help of IDisplayModel.
/// </summary>
public interface IDisplayRepository
{
    #region methods

    /// <summary>
    /// Call this if you want to receive list of currently active displays.
    /// What does "active" mean in our context? It means the monitors that are "enabled"
    /// in Desktop properties screen.
    /// </summary>
    /// <returns>list of active monitors</returns>
    IEnumerable<DisplayModel> GetActiveDisplays();

    /// <summary>
    /// Returns all displays.
    /// </summary>
    /// <returns></returns>
    IEnumerable<DisplayModel> GetAllDisplays();

    /// <summary>
    /// Gets the display by its id.
    /// </summary>
    /// <returns>current the display</returns>
    DisplayModel GetDisplayById(int id);

    /// <summary>
    /// Gets the primary display.
    /// </summary>
    /// <returns>current **active** primary display</returns>
    DisplayModel GetPrimaryDisplay();

    /// <summary>
    /// Tries to set resolution of a display.
    /// </summary>
    /// <param name="display">The display which should change the resolution</param>
    /// <param name="newResolution">new resolution</param>
    /// <returns>true if successful, false otherwise.</returns>
    bool SetResolution(DisplayModel display, Size newResolution);

    /// <summary>
    /// Tries to set to rotation of display.
    /// </summary>
    /// <param name="display">The display which should change the rotation</param>
    /// <param name="rotation">the value of rotation</param>
    /// <returns>true if successful, false otherwise.</returns>
    bool SetRotation(DisplayModel display, DisplayRotation rotation);

    /// <summary>
    /// Tries to set display as active.
    /// </summary>
    /// <returns>true if successful, false otherwise.</returns>
    bool TurnOff(DisplayModel display);

    /// <summary>
    /// Tries to set display as deactivate.
    /// </summary>
    /// <returns>true if successful, false otherwise</returns>
    bool TurnOn(DisplayModel display);

    #endregion
}