namespace Logic.Core.Structures;

using System.Runtime.InteropServices;

using Interfaces;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DisplayConfigSetTargetPersistence : IDisplayConfigInfo
{
    public DisplayConfigDeviceInfoHeader header;

    private uint _raw;

    public bool BootPersistenceOn
    {
        get => (_raw & (1 << 0)) != 0;
        set
        {
            if (value)
            {
                _raw |= 1; // set first bit as 1
            }
            else
            {
                _raw &= ~(uint)1; // set first bit as 0
            }
        }
    }
}