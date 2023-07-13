namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Luid
{
    public uint LowPart;
    public uint HighPart;
}