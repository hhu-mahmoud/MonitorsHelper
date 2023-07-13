namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfigTargetMode
{
    public DisplayConfigVideoSignalInfo targetVideoSignalInfo;
}