namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfig2DRegion
{
    public uint cx;
    public uint cy;
}