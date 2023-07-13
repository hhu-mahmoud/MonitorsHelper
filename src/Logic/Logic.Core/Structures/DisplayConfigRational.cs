namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfigRational
{
    public uint numerator;
    public uint denominator;
}