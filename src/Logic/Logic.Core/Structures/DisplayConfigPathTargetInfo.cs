namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Enumerations.Flags;

[StructLayout(LayoutKind.Sequential)]
public struct DisplayConfigPathTargetInfo
{
    public Luid adapterId;
    public uint id;
    public uint modeInfoIdx;
    public DisplayConfigVideoOutputTechnology outputTechnology;
    public DisplayConfigRotation rotation;
    public DisplayConfigScaling scaling;
    public DisplayConfigRational refreshRate;
    public DisplayConfigScanLineOrdering scanLineOrdering;

    public bool targetAvailable;
    public DisplayConfigTargetStatus statusFlags;
}