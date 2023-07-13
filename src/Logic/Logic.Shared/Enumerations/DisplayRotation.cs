﻿namespace Logic.Shared.Enumerations;

/// <summary>
/// Indicates degrees of current display.
/// </summary>
[Flags]
public enum DisplayRotation
{
    /// <summary>
    /// No rotation applied
    /// </summary>
    Default,

    /// <summary>
    /// Rotated 90 degrees
    /// </summary>
    Rotated90,

    /// <summary>
    /// Rotated 180 degrees
    /// </summary>
    Rotated180,

    /// <summary>
    /// Rotated 270 degrees
    /// </summary>
    Rotated270
}