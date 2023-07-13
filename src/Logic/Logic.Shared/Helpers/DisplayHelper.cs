namespace Logic.Shared.Helpers;

using System.Runtime.InteropServices;

using Core.Enumerations;
using Core.Structures;
using Core.Utils;
using Logic.Core.Enumerations.Flags;

internal static class DisplayHelper
{
    #region methods

    /// <summary>
    /// This method give you access to monitor device name.
    /// Such as "\\DISPLAY1"
    /// </summary>
    /// <param name="sourceModeInfo"></param>
    /// <param name="displayConfigSourceDeviceName"></param>
    /// <returns></returns>
    public static StatusCode GetDisplayConfigSourceDeviceName(DisplayConfigModeInfo sourceModeInfo, out DisplayConfigSourceDeviceName displayConfigSourceDeviceName)
    {
        displayConfigSourceDeviceName = new DisplayConfigSourceDeviceName
        {
            header = new DisplayConfigDeviceInfoHeader
            {
                adapterId = sourceModeInfo.adapterId,
                id = sourceModeInfo.id,
                size = Marshal.SizeOf(typeof(DisplayConfigSourceDeviceName)),
                type = DisplayConfigDeviceInfoType.GetSourceName
            }
        };
        return Utility.DisplayConfigGetDeviceInfo(ref displayConfigSourceDeviceName);
    }

    /// <summary>
    /// This method can be used in order to filter out specific paths that we are interested,
    /// a long with their corresponding paths.
    /// </summary>
    /// <param name="pathType"></param>
    /// <param name="topologyId"></param>
    /// <returns></returns>
    public static IEnumerable<DisplayConfigPathWrap> GetPathWraps(QueryDisplayFlags pathType, out DisplayConfigTopologyId topologyId)
    {
        topologyId = DisplayConfigTopologyId.Zero;
        var status = Utility.GetDisplayConfigBufferSizes(pathType, out var numPathArrayElements, out var numModeInfoArrayElements);
        if (status != StatusCode.Success)
        {
            // TODO; POSSIBLY HANDLE SOME OF THE CASES.
            var reason = $"GetDisplayConfigBufferSizesFailed() failed. Status: {status}";
            throw new Exception(reason);
        }
        var pathInfoArray = new DisplayConfigPathInfo[numPathArrayElements];
        var modeInfoArray = new DisplayConfigModeInfo[numModeInfoArrayElements];

        // topology ID only valid with QDC_DATABASE_CURRENT
        var queryDisplayStatus = pathType == QueryDisplayFlags.DatabaseCurrent
            ? Utility.QueryDisplayConfig(pathType, ref numPathArrayElements, pathInfoArray, ref numModeInfoArrayElements, modeInfoArray, out topologyId)
            : Utility.QueryDisplayConfig(pathType, ref numPathArrayElements, pathInfoArray, ref numModeInfoArrayElements, modeInfoArray);
        //////////////////////
        if (queryDisplayStatus == StatusCode.Success)
        {
            return (from path in pathInfoArray
                let outputModes = (from modeIndex in new[] { path.sourceInfo.modeInfoIdx, path.targetInfo.modeInfoIdx } where modeIndex < modeInfoArray.Length select modeInfoArray[modeIndex]).ToList()
                select new DisplayConfigPathWrap(path, outputModes)).ToList();
        }
        {
            // TODO; POSSIBLY HANDLE SOME OF THE CASES.
            var reason = $"QueryDisplayConfig() failed. Status: {queryDisplayStatus}";
            throw new Exception(reason);
        }
    }

    #endregion
}