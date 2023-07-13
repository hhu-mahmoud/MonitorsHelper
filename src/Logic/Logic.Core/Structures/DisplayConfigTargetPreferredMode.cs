namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Interfaces;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfigTargetPreferredMode : IDisplayConfigInfo
{
    public DisplayConfigDeviceInfoHeader header;
    public uint width;
    public uint height;
    public DisplayConfigTargetMode targetMode;
}