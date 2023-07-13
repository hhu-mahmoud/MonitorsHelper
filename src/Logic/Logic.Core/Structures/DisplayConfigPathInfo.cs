namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Enumerations.Flags;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfigPathInfo
{
    public DisplayConfigPathSourceInfo sourceInfo;
    public DisplayConfigPathTargetInfo targetInfo;
    public DisplayConfigFlags flags;
}