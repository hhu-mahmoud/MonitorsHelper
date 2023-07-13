namespace Logic.Core.Enumerations.Flags;

[Flags]
public enum DisplayConfigTopologyId : uint
{
    Zero = 0x0,
    Internal = 0x00000001,
    Clone = 0x00000002,
    Extend = 0x00000004,
    External = 0x00000008
}