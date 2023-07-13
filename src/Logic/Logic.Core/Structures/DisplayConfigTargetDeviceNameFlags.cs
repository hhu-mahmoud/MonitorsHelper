namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public struct DisplayConfigTargetDeviceNameFlags
{
    [FieldOffset(0)]
    private readonly uint _raw;

    [FieldOffset(0)]
    public uint value;

    // TODO; Factor out the extracting bits from RAW.

    /// <summary>
    /// Get first bit from the raw field.
    /// </summary>
    public byte FriendlyNameFromEdid => (byte)(_raw & (1 << 0));

    /// <summary>
    /// Get second bit from the raw field.
    /// </summary>
    public byte FriendlyNameForced => (byte)(_raw & (1 << 1));

    /// <summary>
    /// Get third bit from the raw field.
    /// </summary>
    public byte EdidIdsValid => (byte)(_raw & (1 << 2));

    // TODO; Bring out the reserved bits, 29 last ones.
    //public byte Reserved {get{return (byte)((raw>>11)&0x1F);}}
}