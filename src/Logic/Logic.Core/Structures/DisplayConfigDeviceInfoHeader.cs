namespace Logic.Core.Structures
{
    using System.Runtime.InteropServices;

    using Enumerations;

    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayConfigDeviceInfoHeader
    {
        public DisplayConfigDeviceInfoType type;
        public int size;
        public Luid adapterId;
        public int id;
    }
}