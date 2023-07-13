namespace Logic.Core.Enumerations;

/// <summary>
/// Use this enum so that you don't have to hardcoded magic values.
/// </summary>
public enum StatusCode : uint
{
    Success = 0,
    InvalidParameter = 87,
    NotSupported = 50,
    AccessDenied = 5,
    GenFailure = 31,
    BadConfiguration = 1610,
    InSufficientBuffer = 122
}