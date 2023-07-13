namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Interfaces;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DisplayConfigSourceDeviceName : IDisplayConfigInfo
{
    private const int Cchdevicename = 32;

    public DisplayConfigDeviceInfoHeader header;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Cchdevicename)]
    public string viewGdiDeviceName;
}