namespace Logic.Shared.Models;

using System.Drawing;

using Enumerations;

/// <summary>
/// Each monitor is abstracted away with help of IDisplay.
/// </summary>
public class DisplayModel
{
    #region properties

    /// <summary>
    /// Display representation on system. Such as 1
    /// </summary>
    public int Id { get; internal init; }

    /// <summary>
    /// <c>True</c> if the display is active
    /// </summary>
    public bool IsActive { get; internal set; }

    /// <summary>
    /// Indicates whenever display is primary or not.
    /// The logic is simple, according to MSDN:
    /// For display devices only, a POINTL structure that indicates the positional coordinates of
    /// the display device in reference to the desktop area. The primary display device is always located
    /// at coordinates (0,0).
    /// </summary>
    /// <returns></returns>
    public bool IsPrimary => Origin is { X: 0, Y: 0 };

    /// <summary>
    /// Display representation on system. Such as \\.\\DISPLAY1
    /// </summary>
    public string Name { get; internal init; }

    /// <summary>
    /// Indicates the coordinates of origin where monitor area starts from.
    /// That is left-top coordinates.
    /// </summary>
    public Point Origin { get; internal init; }

    /// <summary>
    /// Indicates refresh rate of monitor. This is vertical refresh rate.
    /// </summary>
    public int RefreshRate { get; internal set; }

    /// <summary>
    /// Returns the resolution of display. In pixels.
    /// </summary>
    public Size Resolution { get; internal set; }

    /// <summary>
    /// Indicates degrees of rotation.
    /// </summary>
    public DisplayRotation Rotation { get; internal set; }

    #endregion
}