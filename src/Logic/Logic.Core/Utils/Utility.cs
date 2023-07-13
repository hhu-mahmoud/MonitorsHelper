namespace Logic.Core.Utils;

using System.Runtime.InteropServices;

using Enumerations;
using Enumerations.Flags;

using Interfaces;

using Structures;

public static class Utility
{
    #region constants

    private const int EnumCurrentSettings = -1;

    #endregion

    #region methods

    public static StatusCode DisplayConfigGetDeviceInfo<T>(ref T displayConfig)
        where T : IDisplayConfigInfo
    {
        return MarshalStructureAndCall(ref displayConfig, DisplayConfigGetDeviceInfo);
    }

    public static StatusCode DisplayConfigSetDeviceInfo<T>(ref T displayConfig)
        where T : IDisplayConfigInfo
    {
        return MarshalStructureAndCall(ref displayConfig, DisplayConfigSetDeviceInfo);
    }

    public static DEVMODE GetDevMode(string deviceName)
    {
        var dm = new DEVMODE
        {
            dmSize = (short)Marshal.SizeOf(typeof(DEVMODE))
        };
        EnumDisplaySettings(deviceName, EnumCurrentSettings, ref dm);
        return dm;
    }

    [DllImport("User32.dll")]
    public static extern StatusCode GetDisplayConfigBufferSizes(QueryDisplayFlags flags, out int numPathArrayElements, out int numModeInfoArrayElements);

    [DllImport("User32.dll")]
    public static extern StatusCode QueryDisplayConfig(
        QueryDisplayFlags flags,
        ref int numPathArrayElements,
        [Out] DisplayConfigPathInfo[] pathInfoArray,
        ref int modeInfoArrayElements,
        [Out] DisplayConfigModeInfo[] modeInfoArray,
        IntPtr topologyId = default);

    [DllImport("User32.dll")]
    public static extern StatusCode QueryDisplayConfig(
        QueryDisplayFlags flags,
        ref int numPathArrayElements,
        [Out] DisplayConfigPathInfo[] pathInfoArray,
        ref int modeInfoArrayElements,
        [Out] DisplayConfigModeInfo[] modeInfoArray,
        out DisplayConfigTopologyId topologyId);

    [DllImport("User32.dll")]
    public static extern StatusCode SetDisplayConfig(int numPathArrayElements, [In] DisplayConfigPathInfo[] pathArray, int numModeInfoArrayElements, [In] DisplayConfigModeInfo[] modeInfoArray, SdcFlags flags);

    [DllImport("User32.dll")]
    public static extern StatusCode SetDisplayConfig(int numPathArrayElements, [In] IntPtr pathArray, int numModeInfoArrayElements, [In] IntPtr modeInfoArray, SdcFlags flags);

    [DllImport("User32.dll")]
    private static extern StatusCode DisplayConfigGetDeviceInfo(IntPtr requestPacket);

    [DllImport("User32.dll")]
    private static extern StatusCode DisplayConfigSetDeviceInfo(IntPtr requestPacket);

    [DllImport("user32.dll")]
    private static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

    /// <summary>
    /// The idea of this method is to make sure we have type-safety, without any stupid overloads.
    /// Without this, you would need to marshal yourself everything when using DisplayConfigGetDeviceInfo,
    /// or SetDeviceInfo, without any type-safety.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="displayConfig"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    private static StatusCode MarshalStructureAndCall<T>(ref T displayConfig, Func<IntPtr, StatusCode> func)
        where T : IDisplayConfigInfo
    {
        try
        {
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(displayConfig));
            Marshal.StructureToPtr(displayConfig, ptr, false);
            var returnValue = func(ptr);
            displayConfig = (T)Marshal.PtrToStructure(ptr, displayConfig.GetType());
            Marshal.FreeHGlobal(ptr);
            return returnValue;
        }
        catch (OutOfMemoryException ex)
        {
            // TODO: Handle the System.OutOfMemoryException
        }
        catch (ArgumentNullException ex)
        {
            // TODO: Handle the System.ArgumentNullException
        }
        catch (ArgumentException ex)
        {
            // TODO: Handle the System.ArgumentException
        }
        catch (Exception ex)
        {
            // TODO: Handle the System.Exception
        }
        return StatusCode.GenFailure;
    }

    #endregion
}