namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Enumerations.Flags;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfigSourceMode
{
    public int width;
    public int height;
    public DisplayConfigPixelFormat pixelFormat;
    public PointL position;
}