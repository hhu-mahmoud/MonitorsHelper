namespace Logic.Shared.Factories;

using Interfaces;

using Repositories;

/// <summary>
/// Simple display factory class that will choose correct implementation,
/// based on an operating system.
/// </summary>
public static class DisplayFactory
{
    #region constants

    private static IDisplayRepository? _displayRepository;
    private static readonly object Lock = new();

    #endregion

    #region methods

    /// <summary>
    /// Selects correct display repository, based on Windows version.
    /// </summary>
    /// <returns></returns>
    public static IDisplayRepository? Instance()
    {
        lock (Lock)
        {
            if (_displayRepository != null)
            {
                return _displayRepository;
            }
            _displayRepository = new DisplayRepository();
            return _displayRepository;
        }
    }

    #endregion
}