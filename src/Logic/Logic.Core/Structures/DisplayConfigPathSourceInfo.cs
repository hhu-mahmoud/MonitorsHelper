namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Enumerations.Flags;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfigPathSourceInfo
{
    public Luid adapterId;
    public uint id;
    public uint modeInfoIdx;

    public DisplayConfigSourceStatus statusFlags;
}