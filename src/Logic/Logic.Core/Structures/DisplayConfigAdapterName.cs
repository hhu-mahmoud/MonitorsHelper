namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Interfaces;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DisplayConfigAdapterName : IDisplayConfigInfo
{
    public DisplayConfigDeviceInfoHeader header;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string adapterDevicePath;
}