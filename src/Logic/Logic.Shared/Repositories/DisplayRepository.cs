namespace Logic.Shared.Repositories;

using System.Drawing;

using BaseRepository;

using Core.Enumerations;
using Core.Enumerations.Flags;
using Core.Structures;
using Core.Utils;

using Enumerations;

using Extensions;

using Helpers;

using Models;

internal class DisplayRepository : BaseDisplayRepository
{
    #region methods

    /// <inheritdoc cref="BaseDisplayRepository" />
    public override IEnumerable<DisplayModel> GetActiveDisplays()
    {
        var pathWraps = DisplayHelper.GetPathWraps(QueryDisplayFlags.OnlyActivePaths, out _);

        // convert pathWrap elements to IDisplay elements(actually Win7Display elements)
        return pathWraps.Select(CreateDisplay);
    }

    /// <inheritdoc cref="BaseDisplayRepository" />
    public override IEnumerable<DisplayModel> GetAllDisplays()
    {
        var pathWraps = DisplayHelper.GetPathWraps(QueryDisplayFlags.DatabaseCurrent, out _);

        // convert pathWrap elements to IDisplay elements(actually Win7Display elements)
        return pathWraps.Select(CreateDisplay);
    }

    /// <inheritdoc cref="BaseDisplayRepository" />
    public override bool SetResolution(DisplayModel display, Size newResolution)
    {
        display.Resolution = newResolution;
        return true;
    }

    /// <inheritdoc cref="BaseDisplayRepository" />
    public override bool SetRotation(DisplayModel display, DisplayRotation rotation)
    {
        display.Rotation = rotation;
        return true;
    }

    /// <inheritdoc cref="BaseDisplayRepository" />
    public override bool TurnOff(DisplayModel display)
    {
        try
        {
            // Get the necessary display information
            Utility.GetDisplayConfigBufferSizes(QueryDisplayFlags.OnlyActivePaths, out var numPathArrayElements, out var numModeInfoArrayElements);
            var pathInfoArray = new DisplayConfigPathInfo[numPathArrayElements];
            var modeInfoArray = new DisplayConfigModeInfo[numModeInfoArrayElements];
            var error = Utility.QueryDisplayConfig(QueryDisplayFlags.OnlyActivePaths, ref numPathArrayElements, pathInfoArray, ref numModeInfoArrayElements, modeInfoArray, nint.Zero);
            if (error != StatusCode.Success)
            {
                return false;
                // QueryDisplayConfig failed
            }

            // Check the index
            if (pathInfoArray[display.Id].sourceInfo.modeInfoIdx >= modeInfoArray.Length)
            {
                return false;
            }

            // Disable and reset the display configuration
            pathInfoArray[display.Id].flags = DisplayConfigFlags.Zero;
            error = Utility.SetDisplayConfig(pathInfoArray.Length, pathInfoArray, modeInfoArray.Length, modeInfoArray, SdcFlags.Apply | SdcFlags.AllowChanges | SdcFlags.UseSuppliedDisplayConfig);
            if (error != StatusCode.Success)
            {
                return false;
                // SetDisplayConfig failed
            }
        }
        catch (OverflowException ex)
        {
            return false;
            // TODO: Handle the System.OverflowException
        }
        return true;
    }

    /// <inheritdoc cref="BaseDisplayRepository" />
    public override bool TurnOn(DisplayModel display)
    {
        try
        {
            // Get the necessary display information
            Utility.GetDisplayConfigBufferSizes(QueryDisplayFlags.DatabaseCurrent, out var numPathArrayElements, out var numModeInfoArrayElements);
            var pathInfoArray = new DisplayConfigPathInfo[numPathArrayElements];
            var modeInfoArray = new DisplayConfigModeInfo[numModeInfoArrayElements];
            var error = Utility.QueryDisplayConfig(QueryDisplayFlags.DatabaseCurrent, ref numPathArrayElements, pathInfoArray, ref numModeInfoArrayElements, modeInfoArray, out _);
            if (error != StatusCode.Success)
            {
                // QueryDisplayConfig failed
            }
            pathInfoArray[display.Id].flags = DisplayConfigFlags.PathActive;
            Utility.SetDisplayConfig(pathInfoArray.Length, pathInfoArray, modeInfoArray.Length, modeInfoArray, SdcFlags.Apply | SdcFlags.AllowChanges | SdcFlags.UseSuppliedDisplayConfig);
            return error == StatusCode.Success;
            // SetDisplayConfig failed
        }
        catch (OverflowException ex)
        {
            return false;
            // TODO: Handle the System.OverflowException
        }
        return false;
    }

    /// <summary>
    /// Creates new instance of Win7Display
    /// </summary>
    /// <returns></returns>
    private static DisplayModel CreateDisplay(DisplayConfigPathWrap pathWrap)
    {
        try
        {
            var path = pathWrap.Path;
            var sourceModeInfo = pathWrap.Modes.First(x => x.infoType == DisplayConfigModeInfoType.Source);
            var origin = new Point
            {
                X = sourceModeInfo.sourceMode.position.x,
                Y = sourceModeInfo.sourceMode.position.y
            };
            var resolution = new Size
            {
                Width = sourceModeInfo.sourceMode.width,
                Height = sourceModeInfo.sourceMode.height
            };
            var denominator = path.targetInfo.refreshRate.denominator;
            if (denominator <= 0)
            {
                throw new ArgumentException("Denminator is equal zero.");
            }
            var refreshRate = (int)Math.Round((double)path.targetInfo.refreshRate.numerator / denominator);
            var rotationOriginal = path.targetInfo.rotation;
            // query for display name.
            var displayName = "<unidentified>"; // TODO: refactor it
            var nameStatus = DisplayHelper.GetDisplayConfigSourceDeviceName(sourceModeInfo, out var displayConfigSourceDeviceName);
            if (nameStatus == StatusCode.Success)
            {
                displayName = displayConfigSourceDeviceName.viewGdiDeviceName;
            }
            return new DisplayModel
            {
                Resolution = resolution,
                Origin = origin,
                Rotation = rotationOriginal.ToScreenRotation(),
                RefreshRate = refreshRate,
                Name = displayName,
                Id = sourceModeInfo.id,
                IsActive = true
            };
        }
        catch (ArgumentNullException ex)
        {
            throw ex;
        }
        catch (InvalidOperationException ex)
        {
            throw ex;
        }
        catch (ArgumentException ex)
        {
            throw ex;
        }
    }

    #endregion
}